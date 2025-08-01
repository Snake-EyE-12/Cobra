using NaughtyAttributes;
using UnityEngine;

namespace Cobra
{
    public class WCT_BlackoutSceneTransition : SceneTransition
    {
        [SerializeField] private RectTransform blackoutScene;
        [SerializeField] private float speed;
        protected override void OnStartChange()
        {
            blackoutScene.gameObject.SetActive(true);
        }

        protected override void OnUpdate()
        {
            blackoutScene.transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }

        protected override bool TransitionComplete()
        {
            return blackoutScene.anchoredPosition.x > 0;
        }
        
        [Button]
        public void DoIt()
        {
            ChangeScene();
        }
    }
}
