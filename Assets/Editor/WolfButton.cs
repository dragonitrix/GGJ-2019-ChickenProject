using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(WolfSpawner))]
public class WolfButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("SpawnWolf"))
        {

            var rot = Random.Range(0f, Mathf.PI) + Mathf.PI / 2;

            var lDirection = new Vector3(Mathf.Sin(rot), 0, Mathf.Cos(rot));
            (target as WolfSpawner).SpawnWolf();
        }
    }


}