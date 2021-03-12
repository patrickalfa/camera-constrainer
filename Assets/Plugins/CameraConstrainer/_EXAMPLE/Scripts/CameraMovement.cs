using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Potreik.CameraConstrainer.Example
{

    [RequireComponent(typeof(CameraConstrainer))]
    public class CameraMovement : MonoBehaviour
    {
        public float Speed;

        private CameraConstrainer constrainer;

        private void Start()
        {
            constrainer = GetComponent<CameraConstrainer>();
        }

        private void Update()
        {
            float h = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
            float v = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

            Vector2 constrainedAxis = constrainer.GetConstrainedAxis(transform.position, new Vector2(h, v));

            transform.position += new Vector3(constrainedAxis.x * h, constrainedAxis.y * v, 0f);
        }
    }
}