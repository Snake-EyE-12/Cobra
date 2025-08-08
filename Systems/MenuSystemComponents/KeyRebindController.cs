using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Cobra.GUI
{
    public class KeyRebindController : MonoBehaviour
    {
        private KeybindingGroupController controller;
        
        [Tooltip("Reference to action that is to be rebound from the UI.")]
        [SerializeField] private InputActionReference m_Action;
        public InputActionReference actionReference
        {
            get => m_Action;
            set
            {
                m_Action = value;
                UpdateActionLabel();
                UpdateBindingDisplay();
            }
        }
        [SerializeField] private string m_BindingId;
        private string m_RebindText;
        private string m_BindText;
        private string m_ActionLabel;
        [SerializeField] private string m_CancelThrough = "<Keyboard>/escape";
        [SerializeField]
        private InputBinding.DisplayStringOptions m_DisplayStringOptions;
        public InputBinding.DisplayStringOptions displayStringOptions
        {
            get => m_DisplayStringOptions;
            set
            {
                m_DisplayStringOptions = value;
                UpdateBindingDisplay();
            }
        }
        public bool IsDuplicate { get; set; }

        
        private InputActionRebindingExtensions.RebindingOperation m_RebindOperation;
        
        [SerializeField] private InteractiveRebindEvent m_RebindStopEvent;
        [SerializeField] private InteractiveRebindEvent m_RebindStartEvent;
        [SerializeField] private UpdateBindingUIEvent m_RebindUpdateEvent;
        
        [Serializable]
        public class InteractiveRebindEvent : UnityEvent<KeyRebindController, InputActionRebindingExtensions.RebindingOperation>
        {
        }
        [Serializable]
        public class UpdateBindingUIEvent : UnityEvent<KeyRebindController, string, string, string>
        {
        }
        
        public void Initialize(KeybindingGroupController controller)
        {
            this.controller = controller;
        }

        public void Save()
        {
            if (!ResolveActionAndBinding(out var action, out var bindingIndex))
                return;

            // Get the override path (null if not overridden)
            var overridePath = action.bindings[bindingIndex].overridePath;

            var saveKey = $"{actionReference.name}_{m_BindingId}";
            PlayerPrefs.SetString(saveKey, overridePath ?? string.Empty);
        }

        public void Load()
        {
            if (!ResolveActionAndBinding(out var action, out var bindingIndex))
                return;

            var saveKey = $"{actionReference.name}_{m_BindingId}";
            var savedOverride = PlayerPrefs.GetString(saveKey, null);

            if (!string.IsNullOrEmpty(savedOverride))
                action.ApplyBindingOverride(bindingIndex, savedOverride);
        }


        private void TryLoadSaveThenDefault()
        {
            if (!ResolveActionAndBinding(out var action, out var bindingIndex))
                return;

            var saveKey = $"{actionReference.name}_{m_BindingId}";
            if (PlayerPrefs.HasKey(saveKey))
            {
                Load();
            }
            else
            {
                ResetToDefault();
            }
        }

        public void ResetToDefault()
        {
            if (!ResolveActionAndBinding(out var action, out var bindingIndex))
                return;

            if (action.bindings[bindingIndex].isComposite)
            {
                // It's a composite. Remove overrides from part bindings.
                for (var i = bindingIndex + 1; i < action.bindings.Count && action.bindings[i].isPartOfComposite; ++i)
                    action.RemoveBindingOverride(i);
            }
            else
            {
                action.RemoveBindingOverride(bindingIndex);
            }
            UpdateBindingDisplay();
        }
        
        
        public void StartInteractiveRebind()
        {
            if (!ResolveActionAndBinding(out var action, out var bindingIndex))
                return;

            // If the binding is a composite, we need to rebind each part in turn.
            if (action.bindings[bindingIndex].isComposite)
            {
                var firstPartIndex = bindingIndex + 1;
                if (firstPartIndex < action.bindings.Count && action.bindings[firstPartIndex].isPartOfComposite)
                    PerformInteractiveRebind(action, firstPartIndex, allCompositeParts: true);
            }
            else
            {
                PerformInteractiveRebind(action, bindingIndex);
            }
        }
        private void PerformInteractiveRebind(InputAction action, int bindingIndex, bool allCompositeParts = false)
        {
            m_RebindOperation?.Cancel(); // Will null out m_RebindOperation.

            void CleanUp()
            {
                m_RebindOperation?.Dispose();
                m_RebindOperation = null;
                action.Enable();
            }

            //Fixes the "InvalidOperationException: Cannot rebind action x while it is enabled" error
            action.Disable();

            // Configure the rebind.
            m_RebindOperation = action.PerformInteractiveRebinding(bindingIndex)
                .WithCancelingThrough(m_CancelThrough)
                .OnCancel(
                    operation =>
                    {
                        m_RebindStopEvent?.Invoke(this, operation);
                        controller.CloseBindingOverlay();
                        //controller.CheckForDuplicateRebindings();
                        UpdateBindingDisplay();
                        CleanUp();
                    })
                .OnComplete(
                    operation =>
                    {
                        m_RebindStopEvent?.Invoke(this, operation);
                        controller.CloseBindingOverlay();
                        //controller.CheckForDuplicateRebindings();
                        UpdateBindingDisplay();
                        CleanUp();

                        // If there's more composite parts we should bind, initiate a rebind
                        // for the next part.
                        if (allCompositeParts)
                        {
                            var nextBindingIndex = bindingIndex + 1;
                            if (nextBindingIndex < action.bindings.Count && action.bindings[nextBindingIndex].isPartOfComposite)
                                PerformInteractiveRebind(action, nextBindingIndex, true);
                        }
                    });

            // If it's a part binding, show the name of the part in the UI.
            var partName = default(string);
            if (action.bindings[bindingIndex].isPartOfComposite)
                partName = $"Binding '{action.bindings[bindingIndex].name}'. ";

            // Bring up rebind overlay, if we have one.
            controller.OpenBindingOverlay();
            if (m_RebindText != null)
            {
                var text = !string.IsNullOrEmpty(m_RebindOperation.expectedControlType)
                    ? $"{partName}Waiting for {m_RebindOperation.expectedControlType} input..."
                    : $"{partName}Waiting for input...";
                m_RebindText = text;
                UpdateBindingDisplay();
            }
            
            // Give listeners a chance to act on the rebind starting.
            m_RebindStartEvent?.Invoke(this, m_RebindOperation);

            m_RebindOperation.Start();
        }
        public bool ResolveActionAndBinding(out InputAction action, out int bindingIndex)
        {
            bindingIndex = -1;

            action = m_Action?.action;
            if (action == null)
                return false;

            if (string.IsNullOrEmpty(m_BindingId))
                return false;

            // Look up binding index.
            var bindingId = new Guid(m_BindingId);
            bindingIndex = action.bindings.IndexOf(x => x.id == bindingId);
            if (bindingIndex == -1)
            {
                Debug.LogError($"Cannot find binding with ID '{bindingId}' on '{action}'", this);
                return false;
            }

            return true;
        }
        private static List<KeyRebindController> s_RebindActionUIs;
        private static void OnActionChange(object obj, InputActionChange change)
        {
            if (change != InputActionChange.BoundControlsChanged)
                return;

            var action = obj as InputAction;
            var actionMap = action?.actionMap ?? obj as InputActionMap;
            var actionAsset = actionMap?.asset ?? obj as InputActionAsset;

            for (var i = 0; i < s_RebindActionUIs.Count; ++i)
            {
                var component = s_RebindActionUIs[i];
                var referencedAction = component.actionReference?.action;
                if (referencedAction == null)
                    continue;

                if (referencedAction == action ||
                    referencedAction.actionMap == actionMap ||
                    referencedAction.actionMap?.asset == actionAsset)
                    component.UpdateBindingDisplay();
            }
        }
        private void UpdateActionLabel()
        {
            if (m_ActionLabel != null)
            {
                var action = m_Action?.action;
                m_ActionLabel = action != null ? action.name : string.Empty;
            }
        }
        public void UpdateBindingDisplay()
        {
            controller?.CheckForDuplicateRebindings();
            var displayString = string.Empty;
            var deviceLayoutName = default(string);
            var controlPath = default(string);

            // Get display string from action.
            var action = m_Action?.action;
            if (action != null)
            {
                var bindingIndex = action.bindings.IndexOf(x => x.id.ToString() == m_BindingId);
                if (bindingIndex != -1)
                    displayString = action.GetBindingDisplayString(bindingIndex, out deviceLayoutName, out controlPath, displayStringOptions);
            }

            // Set on label (if any).
            if (m_BindText != null)
                m_BindText = displayString;

            // Give listeners a chance to configure UI in response.
            m_RebindUpdateEvent?.Invoke(this, displayString, deviceLayoutName, controlPath);
        }
        protected void OnEnable()
        {
            if (s_RebindActionUIs == null)
                s_RebindActionUIs = new List<KeyRebindController>();
            s_RebindActionUIs.Add(this);
            if (s_RebindActionUIs.Count == 1)
                InputSystem.onActionChange += OnActionChange;
            
            TryLoadSaveThenDefault();
        }

        protected void OnDisable()
        {
            m_RebindOperation?.Dispose();
            m_RebindOperation = null;

            s_RebindActionUIs.Remove(this);
            if (s_RebindActionUIs.Count == 0)
            {
                s_RebindActionUIs = null;
                InputSystem.onActionChange -= OnActionChange;
            }
        }
    }
}
