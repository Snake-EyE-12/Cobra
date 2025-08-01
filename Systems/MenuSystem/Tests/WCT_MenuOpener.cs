using System;
using Cobra.GUI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cobra
{
    public class WCT_MenuOpener : MonoBehaviour
    {
        [SerializeField] private MenuControllerDefault menu;
        [SerializeField] private PauseController pause;
        private bool state;

        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                state = !state;
                if (state)
                {
                    menu.Open();
                    pause.Pause();
                }
                else
                {
                    menu.Close();
                    pause.Resume();
                }
            }
        }
    }
}
