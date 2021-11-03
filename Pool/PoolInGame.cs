using System.Collections;
using System.Collections.Generic;
using LP.ComponentStorage;
using Pool;
using Pool.Container;
using UnityEngine;

public abstract class PoolInGame<T> : BasePool where T : Component
{
    [SerializeField] private ObjectPool<T> currentPool;
 
    [Header("Prefab")]
    [SerializeField] private T pooledObject;
    
    /// <summary>
    /// Initialize and preload pool
    /// </summary>
    public virtual void Initialize()
    {
        Debug.LogError("Initialize");
        currentPool = pooledObject.AddPool<T>(PoolKey, InitializeCount, PoolParent);
        
    }

    /// <summary>
    /// get an object from the pool 
    /// </summary>
    /// <returns>T Object </returns>
    public virtual T GetObject()
    {
        var tValue = currentPool.Get();
        if (needPoolBeacon)
        {
            PoolBeacon beacon = null;
            if (!tValue.TryGetComponent(out beacon))
            {
                beacon = tValue.gameObject.AddComponent<PoolBeacon>();
            }

            var beaconToInit = new BaseBeacon<T>();
            beacon.ThisBeacon = beaconToInit;
            beaconToInit.Initialize(this, tValue, beacon);
        }

        if (needSaveCS)
        {
#if CStorage
            ComponentStorage.Add(tValue);
#endif
        }
        return tValue;
    }

    /// <summary>
    /// return object to the Pool
    /// </summary>
    /// <param name="returnValue">T Object</param>
    public virtual void Return(T returnValue)
    {
        currentPool.Return(returnValue);
    }
    

}
