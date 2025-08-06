using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cobra
{
    public abstract class SceneManipulator : MonoBehaviour
    {
        protected bool transitioning;
        protected abstract void Transition();
        protected abstract void StartTransition();
        protected abstract bool IsTransitionComplete();
        protected abstract void EndTransition();

        protected virtual void Update()
        {
            if (!transitioning) return;
            Transition();
            if (IsTransitionComplete())
            {
                transitioning = false;
                EndTransition();
            }
        }

        protected void InitiateTransition()
        {
            StartTransition();
            transitioning = true;
        }
    }

    public abstract class SceneTransitionArrival : SceneManipulator
    {
        protected virtual void Awake()
        {
            InitiateTransition();
        }
    }

    public abstract class SceneTransitionDeparture : SceneManipulator
    {
        [SerializeField] protected string nextScene;
        protected override void EndTransition()
        {
            SceneManager.LoadScene(nextScene);
        }

        [Button]
        public void Change()
        {
            InitiateTransition();
        }
    }
    public class SceneTransitionInstant : SceneTransitionDeparture
    {
        protected override void Transition()
        {
            
        }

        protected override void StartTransition()
        {
            
        }

        protected override bool IsTransitionComplete()
        {
            return true;
        }
    }
}
