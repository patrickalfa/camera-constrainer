using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Potreik.CameraConstrainer
{
    [CustomEditor(typeof(CameraConstraints)), CanEditMultipleObjects]
    public class CameraConstraintsEditor : Editor
    {
        private Transform[] points;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CameraConstraints constraints = target as CameraConstraints;
            
            if (GUILayout.Button("Create Point"))
                constraints.CreatePoint();

            if (GUILayout.Button("Clear"))
                constraints.Clear();
        }

        private void OnSceneGUI()
        {
            Handles.color = CameraConstraintsUtils.GIZMOS_COLOR;

            CameraConstraints constraints = target as CameraConstraints;
            points = constraints.points;

            // Draw line between points
            if (points.Length > 1)
                Handles.DrawPolyLine(System.Array.ConvertAll(points, p => p.position));

            // Draw positions handles
            foreach (Transform point in points)
            {
                EditorGUI.BeginChangeCheck();

                Vector3 newTargetPosition = Handles.PositionHandle(point.position, Quaternion.identity);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(point, "Change Look At Target Position");
                    point.position = newTargetPosition;
                }
            }
        }
    }
}