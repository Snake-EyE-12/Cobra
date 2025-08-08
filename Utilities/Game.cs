using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cobra.Utilities
{
    public static class Game
    {
        private static PauseControl pauseControl = new PauseControl();

        public static void Pause() => pauseControl.Pause();
        public static void Resume() => pauseControl.Resume();
        public static void LoadPauseControls(InputActionAsset inputActionAsset, string[] pausableActionMapNames) => pauseControl.SetPausableActionMaps(inputActionAsset, pausableActionMapNames);
        public static float GetPausedDuration() => pauseControl.GetDuration();
        private class PauseControl
        {
            public bool IsPaused { get; private set; }
            private float previousTimeScale;
            private float timeOfGamePause;
            private InputActionAsset inputAsset;
            private string[] actionMaps;

            public void SetPausableActionMaps(InputActionAsset inputActionAsset, string[] pausableActionMapNames)
            {
                inputAsset = inputActionAsset;
                actionMaps = pausableActionMapNames;
            }

            public void Pause()
            {
                AudioListener.pause = true;
                IsPaused = true;
                timeOfGamePause = Time.unscaledTime;
                previousTimeScale = Time.timeScale;
                Time.timeScale = 0;
                DisableActionMaps();
            }

            private void DisableActionMaps()
            {
                if (actionMaps == null) return;
                foreach (var actionMap in actionMaps)
                {
                    inputAsset.FindActionMap(actionMap).Disable();
                }
            }

            private void EnableActionMaps()
            {
                if (actionMaps == null) return;
                foreach (var actionMap in actionMaps)
                {
                    inputAsset.FindActionMap(actionMap).Enable();
                }
            }

            public void Resume()
            {
                AudioListener.pause = false;
                IsPaused = false;
                Time.timeScale = previousTimeScale;
                EnableActionMaps();
            }

            public float GetDuration()
            {
                if (!IsPaused) return 0;
                return Time.unscaledTime - timeOfGamePause;
            }
        }

        public static void Quit()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.ExitPlaymode();
            #else
                Application.Quit();
            #endif
        }
    }
}
