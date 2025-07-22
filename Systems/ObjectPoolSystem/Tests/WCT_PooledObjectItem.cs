using Cobra.DesignPattern;
using NaughtyAttributes;
using UnityEngine;

namespace Cobra.DesignPattern
{
    public class WCT_PooledObjectItem : MonoBehaviour, Poolable<WCT_PooledObjectItem>
    {

        [Button]
        public void RandomMethodToDoSomething()
        {
            Pool.Release(this);
        }


        public ObjectPool<WCT_PooledObjectItem> Pool { get; set; }

        public void OnSummon()
        {
            gameObject.SetActive(true);
        }

        public void OnRelease()
        {
            gameObject.SetActive(false);
        }
    }
}