using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Potreik.CameraConstrainer
{
    public class CameraConstraints : MonoBehaviour
    {
        public GameObject CreatePoint()
        {
            int index = transform.childCount;

            GameObject point = new GameObject("Point" + index);

            point.transform.parent = transform;
            point.transform.localPosition = Vector3.zero;

            return point;
        }

        public void Clear()
        {
            foreach (Transform point in transform)
                Destroy(point.gameObject);
        }

        public bool PositionsOverlap(Rect cameraBounds)
        {
            int length = transform.childCount;
            if (length > 1)
            {
                for (int i = 0; i < length - 1; i++)
                {
                    Vector2 p1 = transform.GetChild(i).position;
                    Vector2 p2 = transform.GetChild(i + 1).position;

                    if (CameraConstraintsUtils.LineRect(p1, p2, cameraBounds))
                        return true;
                }
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;

            int length = transform.childCount;
            if (length > 1)
            {
                for (int i = 0; i < length - 1; i++)
                {
                    Gizmos.DrawLine(
                        transform.GetChild(i).position,
                        transform.GetChild(i + 1).position
                    );
                }
            }
        }
    }
}