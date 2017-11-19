using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Wall : MonoBehaviour
    {
        public List<Vector2> newPoints = new List<Vector2>();
        private EdgeCollider2D edge;

        // Use this for initialization
        void Start()
        {
            edge = gameObject.AddComponent<EdgeCollider2D>();
            var bottomleft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            var bottomright = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
            var topleft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
            var topright = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            newPoints.Add(bottomleft);
            newPoints.Add(bottomright);
            newPoints.Add(topright);
            newPoints.Add(topleft);
            newPoints.Add(bottomleft);
            edge.points = newPoints.ToArray();
        }

     
    }
}
