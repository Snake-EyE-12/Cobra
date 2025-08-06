using NaughtyAttributes;
using UnityEngine;

namespace Cobra.UnitTesting
{
    public class WCT_BlackRemovalSceneTransition : SceneTransitionArrival
    {
        [SerializeField] private RectTransform blackoutScene;
        [SerializeField] private float speed;
       

        protected override void Transition()
        {
            blackoutScene.transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }

        protected override void StartTransition()
        {
            blackoutScene.gameObject.SetActive(true);
        }

        protected override bool IsTransitionComplete()
        {
            return blackoutScene.anchoredPosition.x < -900;
        }

        protected override void EndTransition()
        {
            blackoutScene.gameObject.SetActive(false);
        }
    }
}
