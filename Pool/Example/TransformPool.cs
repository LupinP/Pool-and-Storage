using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPool : PoolInGame<Transform>
{
    void Awake()
    {
        Initialize();
    }   
}
