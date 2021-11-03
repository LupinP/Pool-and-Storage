using System.Collections;
using System.Collections.Generic;
using LP.ComponentStorage;
using UnityEngine;

public class BaseBeacon<T> : Beacon where T: Component
{
    public PoolInGame<T> Pool { get; private set; }
    public T Component { get; private set; }
    
    /// <summary>
    /// Initialize Beacon
    /// </summary>
    /// <param name="_pool">pool in game</param>
    /// <param name="_component">Component Value</param>
    public void Initialize(PoolInGame<T> _pool, T _component, PoolBeacon baseMono)
    {
        MonoMain = baseMono;
        Component = _component;
        Pool = _pool;
#if CStorage
        ComponentStorage.Add(baseMono);
#endif
    }
    /// <summary>
    /// return object to the pool
    /// </summary>
    public void ReturnToThePool()
    {
        Pool.Return(Component);
    }
    
    private void OnDestroy()
    {
#if CStorage
        ComponentStorage.Remove(MonoMain);
#endif
    }
}