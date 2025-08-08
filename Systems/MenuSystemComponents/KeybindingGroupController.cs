using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cobra.GUI
{
    public class KeybindingGroupController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionMap;
        private KeyRebindController[] groupRebindControllers;
        private void Awake()
        {
            groupRebindControllers = GetComponentsInChildren<KeyRebindController>();
            foreach (var mp in groupRebindControllers)
            {
                mp.Initialize(this);
            }
        }

        public void ResetAll()
        {
            foreach (var groupRebindController in groupRebindControllers)
            {
                groupRebindController.ResetToDefault();
            }
        }

        [SerializeField] private GameObject bindingOverlayObject;
        public void CloseBindingOverlay()
        {
            bindingOverlayObject.SetActive(false);
        }

        public void OpenBindingOverlay()
        {
            bindingOverlayObject.SetActive(true);
        }

        public void Save()
        {
            foreach (var groupRebindController in groupRebindControllers)
            {
                groupRebindController.Save();
            }
        }

        public void Load()
        {
            foreach (var groupRebindController in groupRebindControllers)
            {
                groupRebindController.Load();
            }
        }
        public void CheckForDuplicateRebindings()
        {
            foreach (var mp in groupRebindControllers)
            {
                mp.IsDuplicate = false;
            }
            Dictionary<string, List<int>> bindingPathToControllerIndices = new Dictionary<string, List<int>>();

            for (int i = 0; i < groupRebindControllers.Length; i++)
            {
                groupRebindControllers[i].IsDuplicate = false;

                var actionRef = groupRebindControllers[i].actionReference;
                if (actionRef == null || actionRef.action == null)
                    continue;

                foreach (var binding in actionRef.action.bindings)
                {
                    string path = binding.effectivePath;
                    if (string.IsNullOrEmpty(path))
                        continue;

                    if (!bindingPathToControllerIndices.TryGetValue(path, out var indices))
                    {
                        indices = new List<int>();
                        bindingPathToControllerIndices[path] = indices;
                    }

                    indices.Add(i);
                }
            }

            // Mark duplicates
            foreach (var kvp in bindingPathToControllerIndices)
            {
                if (kvp.Value.Count > 1)
                {
                    foreach (int index in kvp.Value)
                    {
                        groupRebindControllers[index].IsDuplicate = true;
                    }
                }
            }
        }
    }
}
