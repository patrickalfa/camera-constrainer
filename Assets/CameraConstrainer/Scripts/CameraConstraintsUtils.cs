using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Potreik.CameraConstrainer
{
    public class CameraConstraintsUtils : MonoBehaviour
    {
        public static bool LineLine(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float uA = ((p4.x - p3.x) * (p1.y - p3.y) - (p4.y - p3.y) * (p1.x - p3.x)) / ((p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y));
            float uB = ((p2.x - p1.x) * (p1.y - p3.y) - (p2.y - p1.y) * (p1.x - p3.x)) / ((p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y));

            return (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1);
        }

        public static bool LineRect(Vector2 p1, Vector2 p2, Rect r)
        {
            bool left = LineLine(p1, p2, new Vector2(r.x, r.y), new Vector2(r.x, r.y + r.height));
            bool right = LineLine(p1, p2, new Vector2(r.x + r.width, r.y), new Vector2(r.x + r.width, r.y + r.height));
            bool top = LineLine(p1, p2, new Vector2(r.x, r.y), new Vector2(r.x + r.width, r.y));
            bool bottom = LineLine(p1, p2, new Vector2(r.x, r.y + r.height), new Vector2(r.x + r.width, r.y + r.height));

            return (left || right || top || bottom);
        }
    }
}