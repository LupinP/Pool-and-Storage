using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePool : MonoBehaviour
{
    [Header("Key to keep in the pool ")]
    public string PoolKey;
    [Header("parent for folding the object pool ")]
    public Transform PoolParent;
    [Header("Preloading object count")]
    public int InitializeCount = 10;
    [Header("Do i need a beacon ")]
    public bool needPoolBeacon = true;
    [Header("[Module] need add object to the Component Storage")]
    public bool needSaveCS = true;
}
