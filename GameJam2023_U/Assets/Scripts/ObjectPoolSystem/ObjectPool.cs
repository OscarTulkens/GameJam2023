using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAE.ObjectPool
{
    public class ObjectPoolCreatedEventArgs<TPoolableObject> : EventArgs
    {
        public TPoolableObject poolableObject { get; }

        public ObjectPoolCreatedEventArgs(TPoolableObject poolableObject)
        {
            this.poolableObject = poolableObject;
        }
    }


    public class ObjectPool<TPoolableObject> : MonoBehaviour where TPoolableObject : MonoBehaviour
    {
        //Pool
        public TPoolableObject PoolObjectBase;

        //list of pooled objects
        private List<TPoolableObject> PoolObjects = new List<TPoolableObject>();

        //How many PoolObjects do we start with when the game starts
        private int _initialSize = 10;

        //Sometimes it can be good to put a limit to how many PoolObjects we can isntantiate or we might get millions of them
        private int _maxSize = 20;

        //PArent of the object pool list in the scene, for orginisational purposes
        private Transform _poolParent;

        //call this when u want to initialize object pool
        public void InitializeObjectPool(TPoolableObject poolObjectBase, Transform poolParent, int iNITIAL_POOL_SIZE, int mAX_POOL_SIZE)
        {
            PoolObjectBase = poolObjectBase;
            _initialSize = iNITIAL_POOL_SIZE;
            _maxSize = mAX_POOL_SIZE;
            _poolParent = poolParent;

            if (PoolObjectBase == null)
            {
                Debug.LogError("Need a reference to the Pool Object base prefab");
            }

            //Instantiate new PoolObjects and put them in a list for later use
            for (int i = 0; i < _initialSize; i++)
            {
                GeneratePoolObject();
            }
        }

        //public List<TPoolableObject> GetObjectPoolList()
        //{
        //    return PoolObjects;
        //}

        //Generate a single new PoolObject and put it in list
        private void GeneratePoolObject()
        {
            TPoolableObject NewPoolObject = Instantiate(PoolObjectBase, _poolParent);       

            OnPoolObjectCreated(new ObjectPoolCreatedEventArgs<TPoolableObject>(NewPoolObject));

            NewPoolObject.gameObject.SetActive(false);

            PoolObjects.Add(NewPoolObject);
        }

        private void GeneratePoolObject(Vector3 SpawnLocation)
        {
            TPoolableObject NewPoolObject = Instantiate(PoolObjectBase, _poolParent);

            OnPoolObjectCreated(new ObjectPoolCreatedEventArgs<TPoolableObject>(NewPoolObject));

            NewPoolObject.transform.position = SpawnLocation;

            NewPoolObject.gameObject.SetActive(false);

            PoolObjects.Add(NewPoolObject);
        }

        private void GeneratePoolObject(Transform SpawnLocation)
        {
            TPoolableObject NewPoolObject = Instantiate(PoolObjectBase, _poolParent);

            OnPoolObjectCreated(new ObjectPoolCreatedEventArgs<TPoolableObject>(NewPoolObject));

            NewPoolObject.transform.position = SpawnLocation.position;

            NewPoolObject.gameObject.SetActive(false);

            PoolObjects.Add(NewPoolObject);
        }

        //get object pool object
        public TPoolableObject GetPoolableObject()
        {
            //Try to find an inactive PoolObject
            for (int i = 0; i < PoolObjects.Count; i++)
            {
                TPoolableObject ThisPoolObject = PoolObjects[i];

                if (!ThisPoolObject.gameObject.activeInHierarchy)
                {
                    ThisPoolObject.gameObject.SetActive(true);
                    return ThisPoolObject;
                }
            }

            //We are out of PoolObjects so we have to instantiate another bullet (if we can)
            if (PoolObjects.Count < _maxSize)
            {
                GeneratePoolObject();

                //The new PoolObject is last in the list so get it
                TPoolableObject LastPoolObject = PoolObjects[PoolObjects.Count - 1];

                return LastPoolObject;
            }

            return null;
        }

        public TPoolableObject GetPoolableObject(Vector3 SpawnLocation)
        {
            //Try to find an inactive PoolObject
            for (int i = 0; i < PoolObjects.Count; i++)
            {
                TPoolableObject ThisPoolObject = PoolObjects[i];

                if (!ThisPoolObject.gameObject.activeInHierarchy)
                {
                    ThisPoolObject.transform.position = SpawnLocation;

                    ThisPoolObject.gameObject.SetActive(true);
                    return ThisPoolObject;
                }
            }

            //We are out of PoolObjects so we have to instantiate another bullet (if we can)
            if (PoolObjects.Count < _maxSize)
            {
                GeneratePoolObject(SpawnLocation);

                //The new PoolObject is last in the list so get it
                TPoolableObject LastPoolObject = PoolObjects[PoolObjects.Count - 1];

                return LastPoolObject;
            }

            return null;
        }

        public TPoolableObject GetPoolableObject(Transform SpawnLocation)
        {
            //Try to find an inactive PoolObject
            for (int i = 0; i < PoolObjects.Count; i++)
            {
                TPoolableObject ThisPoolObject = PoolObjects[i];

                if (!ThisPoolObject.gameObject.activeInHierarchy)
                {
                    ThisPoolObject.transform.position = SpawnLocation.position;

                    ThisPoolObject.gameObject.SetActive(true);
                    return ThisPoolObject;
                }
            }

            //We are out of PoolObjects so we have to instantiate another bullet (if we can)
            if (PoolObjects.Count < _maxSize)
            {
                GeneratePoolObject(SpawnLocation);

                //The new PoolObject is last in the list so get it
                TPoolableObject LastPoolObject = PoolObjects[PoolObjects.Count - 1];

                return LastPoolObject;
            }

            return null;
        }

        //return poolableobject back to object pool parent
        public void ReturnPoolableObject(GameObject poolObject)
        {
           
            poolObject.transform.localScale = new Vector3(1, 1, 1);
            poolObject.transform.SetParent(_poolParent);
            poolObject.gameObject.SetActive(false);
          
        }


        //event gets send out everytime a new poolobject is made
        //used to hook up event to the newly instanciated object
        public event EventHandler<ObjectPoolCreatedEventArgs<TPoolableObject>> PoolObjectCreated;

        protected virtual void OnPoolObjectCreated(ObjectPoolCreatedEventArgs<TPoolableObject> e)
        {
            var handler = PoolObjectCreated;
            handler?.Invoke(this, e);
        }

    }
}
