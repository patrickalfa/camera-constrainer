using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Potreik.CameraConstrainer
{
    [ExecuteInEditMode]
    public class CameraConstraints : MonoBehaviour
    {
        public Transform[] points {
            get
            {
                Transform[] ret = new Transform[transform.childCount];
                for (int i = 0; i < transform.childCount; i++)
                    ret[i] = transform.GetChild(i);
                
                return ret;
            }
        }

        public GameObject CreatePoint()
        {
            int index = transform.childCount;
            Transform lastPoint = transform.GetChild(transform.childCount - 1);

            GameObject point = new GameObject("Point" + index);
            point.transform.parent = transform;
            point.transform.localPosition = (lastPoint ? lastPoint.position : Vector3.zero);

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

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = CameraConstraintsUtils.GIZMOS_COLOR;

            foreach (Transform point in transform)
                Gizmos.DrawCube(point.position, Vector3.one * .25f);
        }
    }
}