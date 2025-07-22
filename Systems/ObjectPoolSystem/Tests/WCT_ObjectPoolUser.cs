using Cobra.DesignPattern;
using NaughtyAttributes;
using UnityEngine;


namespace Cobra.DesignPattern
{
    public class WCT_ObjectPoolUser : MonoBehaviour
    {
        [SerializeField] private ObjectPool<WCT_PooledObjectItem> itemPool = new ObjectPool<WCT_PooledObjectItem>();

        [Button]
        public void method()
        {
            itemPool.Summon();
        }
    }
}