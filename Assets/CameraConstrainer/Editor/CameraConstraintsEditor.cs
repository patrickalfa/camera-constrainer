using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Potreik.CameraConstrainer
{
    [CustomEditor(typeof(CameraConstraints))]
    public class CameraConstraintsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CameraConstraints constraints = (CameraConstraints)target;

            if (GUILayout.Button("Create Point"))
                Selection.activeObject = constraints.CreatePoint();

            if (GUILayout.Button("Clear"))
                constraints.Clear();
        }
    }
}