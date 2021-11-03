using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentStorageParameters
{
    [SetSettings]
    private static void SetDefine()
    {
        DefineSetter.SetData("CStorage");
    }
}
