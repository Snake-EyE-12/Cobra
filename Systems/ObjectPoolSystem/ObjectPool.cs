using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Cobra.DesignPattern
{
    [Serializable]
    public class ObjectPool<T> where T :  MonoBehaviour, Poolable<T>
    {
        [SerializeField] private T prefab;
        private Queue<T> inactiveObjects = new Queue<T>();
        
        public T Summon()
        {
            T toSummon = GetNewOrInactive();
            toSummon.OnSummon();
            toSummon.Pool = this;
            return toSummon;
        }

        public T Summon(Transform parent)
        {
            T toSummon = GetNewOrInactive();
            toSummon.transform.parent = parent;
            toSummon.OnSummon();
            toSummon.Pool = this;
            return toSummon;
        }

        public T Summon(Vector3 position)
        {
            T toSummon = GetNewOrInactive();
            toSummon.transform.position = position;
            toSummon.OnSummon();
            toSummon.Pool = this;
            return toSummon;
        }
        
        public T Summon(Vector3 position, Transform parent)
        {
            T toSummon = GetNewOrInactive();
            toSummon.transform.position = position;
            toSummon.transform.parent = parent;
            toSummon.OnSummon();
            toSummon.Pool = this;
            return toSummon;
        }

        public T Summon(Vector3 position, Quaternion rotation)
        {
            T toSummon = GetNewOrInactive();
            toSummon.transform.position = position;
            toSummon.transform.rotation = rotation;
            toSummon.OnSummon();
            toSummon.Pool = this;
            return toSummon;
        }

        public T Summon(Vector3 position, Quaternion rotation, Transform parent)
        {
            T toSummon = GetNewOrInactive();
            toSummon.transform.position = position;
            toSummon.transform.rotation = rotation;
            toSummon.transform.parent = parent;
            toSummon.OnSummon();
            toSummon.Pool = this;
            return toSummon;
        }

        private T GetNewOrInactive()
        {
            if (inactiveObjects.Count > 0)
                return inactiveObjects.Dequeue();
            return CreateNew();
        }

        private T CreateNew()
        {
            return Object.Instantiate(prefab);
        }
        
        public void Release(T obj)
        {
            obj.Pool = null;
            obj.OnRelease();
            inactiveObjects.Enqueue(obj);
        }
    }


    public interface Poolable<T> where T : MonoBehaviour, Poolable<T>
    {
        public ObjectPool<T> Pool { get; set; }
        public void OnSummon();
        public void OnRelease();
    }
    //
    // public class TestPooling : MonoBehaviour
    // {
    //     Projectile projectile;
    //     ObjectPool<Projectile> projectilePool = new ObjectPool<Projectile>();
    //
    //     UnityEngine.Pool.ObjectPool<Projectile> projectilePool2 = new UnityEngine.Pool.ObjectPool<Projectile>(
    //         createFunc: () => Instantiate(projectile),
    //         actionOnGet: (p) => p.gameObject.SetActive(true),
    //         actionOnRelease: (p) => p.gameObject.SetActive(false),
    //         actionOnDestroy: (p) => Destroy(p.gameObject),
    //         collectionCheck: false,
    //         defaultCapacity: 10,
    //         maxSize: 100);
    //     
    //     public void Test()
    //     {
    //         projectile = projectilePool2.Get();
    //         projectilePool2.Release(projectile);
    //     }
    //
    //     public void werwer()
    //     {
    //         projectilePool.Summon()
    //     }
    // }
    //
    // public class Projectile : MonoBehaviour, Poolable
    // {
    //     
    // }
}