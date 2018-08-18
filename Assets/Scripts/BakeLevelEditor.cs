using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BakeLevel))]
public class BakeLevelEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BakeLevel myScript = (BakeLevel)target;
        if (GUILayout.Button("Bake Level"))
        {
            myScript.Bake();
        }
    }
}
