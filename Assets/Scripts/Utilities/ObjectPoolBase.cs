using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Singleton;

namespace Utilities.ObjectPool
{
    public class ObjectPoolBase : MonoSingleton<ObjectPoolBase>
    {
        [SerializeField] private GameObject[] gameObjectArray;
        [SerializeField] private Transform parent;
        [SerializeField] private int poolSize;

        public Queue<GameObject> objectQueue = new Queue<GameObject>();

        public void CreateObjectPool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                var obj = Instantiate(gameObjectArray[Random.Range(0, gameObjectArray.Length)], Vector3.zero, Quaternion.identity, parent);
                obj.gameObject.SetActive(false);
                objectQueue.Enqueue(obj);
            }
        }

        public void CleanPool()
        {
            if (objectQueue.Count > 0)
            {
                int count = objectQueue.Count;
                for (int i = 0; i < count; i++)
                {
                    Debug.Log(objectQueue.Count);
                    Destroy(objectQueue.Dequeue().gameObject);
                    Debug.Log(i);
                }
            }
        }

        public virtual GameObject GetObject()
        {
            GameObject obj = objectQueue.Dequeue();
            objectQueue.Enqueue(obj);
            return obj;
        }

        public GameObject GetSampleObject()
        {
            return objectQueue.Peek();
        }
    }
}
