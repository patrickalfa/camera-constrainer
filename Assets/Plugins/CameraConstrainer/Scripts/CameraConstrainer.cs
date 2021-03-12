using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Potreik.CameraConstrainer
{
    public class CameraConstrainer : MonoBehaviour
    {
        public Vector2 Bounds;

        public Vector2 GetConstrainedAxis(Vector3 position, Vector2 movement)
        {
            CameraConstraints constraints = FindObjectOfType<CameraConstraints>();

            Vector2 axis = Vector2.zero;

            Vector2 newPosX = position + (Vector3.right * movement.x);
            if (!constraints.PositionsOverlap(new Rect(newPosX - (Bounds / 2f), Bounds)))
                axis.x = 1f;

            Vector2 newPosY = (Vector2)position + (Vector2.up * movement.y);
            if (!constraints.PositionsOverlap(new Rect(newPosY - (Bounds / 2f), Bounds)))
                axis.y = 1f;

            return axis;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1f, 0f, 1f, .25f);
            Gizmos.DrawCube(transform.position, (Vector3)Bounds + Vector3.forward);
        }
    }
}