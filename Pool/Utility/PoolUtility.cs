using System.Collections;
using System.Collections.Generic;
using LP.ComponentStorage;
using Pool;
using UnityEngine;

public static class PoolUtility 
{
    public static void ReturnToPool_Beacon<T>(GameObject gameObject) where T : Component
    {
#if CStorage
        var beacon = ComponentStorage.GetElement<PoolBeacon>(gameObject);
        var currentBeacon = beacon.ThisBeacon as BaseBeacon<T>;
        currentBeacon.ReturnToThePool();
#endif
    }

    public static void ReturnToThePool<T>(this T component) where T: Component
    {
        component.Return();
    }
    public static void ReturnToThePool<T>(this T component, string key) where T: Component
    {
        PoolHandler.Return(key, component);
    }
}
