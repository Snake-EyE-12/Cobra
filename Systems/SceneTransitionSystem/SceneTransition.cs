using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cobra
{
    public abstract class SceneTransition : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        private bool transitioning = false;

        public void ChangeScene()
        {
            transitioning = true;
            OnStartChange();
        }

        private void Update()
        {
            if (transitioning)
            {
                OnUpdate();
                if(TransitionComplete()) OnCompleteTransition();
            }
        }

        protected abstract void OnStartChange();
        protected abstract void OnUpdate();
        protected abstract bool TransitionComplete();

        private void OnCompleteTransition()
        {
            transitioning = false;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
