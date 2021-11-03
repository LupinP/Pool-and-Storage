using System.Linq;
using UnityEditor;

public static class DefineSetter
{
    public static void SetData(string value)
    {
        var defs = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        var splitedDefs = defs.Split(';').ToList();
        
        if (!splitedDefs.Contains(value))
        {
            splitedDefs.Add(value);
        }
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, string.Join ( ";", splitedDefs.ToArray () ) );
    }
    
}
