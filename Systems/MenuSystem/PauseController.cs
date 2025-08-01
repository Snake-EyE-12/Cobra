using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cobra.GUI
{
    public class PauseController : MonoBehaviour
    {
        private float previousTimeScale;
        [SerializeField] private InputActionAsset inputSystem;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private string actionMapToggle;
        public void Pause()
        {
            AudioListener.pause = true;
            previousTimeScale = Time.timeScale;
            //playerInput.actions.Disable();
            
            Time.timeScale = 0;
        }

        public void Resume()
        {
            AudioListener.pause = false;
            Time.timeScale = previousTimeScale;
        }

        [Button]
        public void disableActions()
        {
            inputSystem.FindActionMap(actionMapToggle).Disable();
        }
    }
}
