using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cobra
{
    public class MainMenuController : MonoBehaviour
    {
        public GameObject settingsPanel;

        public string targetSceneName = "ENTER SCENE NAME";

        public void OnPlayPressed()
        {
            SceneManager.LoadScene(targetSceneName);
        }

        public void OnSettingsPressed()
        {
            settingsPanel.SetActive(true);
        }

        public void OnQuitPressed()
        {
#if UNITY_EDITOR
            if(EditorApplication.isPlaying)
            {
                EditorApplication.ExitPlaymode();
            }
#else
            Application.Quit();
#endif
        }
    }
}
