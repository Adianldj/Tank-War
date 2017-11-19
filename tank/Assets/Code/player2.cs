using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class player2 : MonoBehaviour
    {
		/*
        // Use this for initialization
        private Rigidbody2D rb;

        private const float FireCooldown = 1f;
        private float _lastfire;

        private static string _fireaxis;

        //private Gun _gun;
        // Use this for initialization
        internal void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            //_gun = GetComponent<Gun>();

            _fireaxis = Platform.GetFireAxis();
        }

        // Update is called once per frame
        internal void Update()
        {
            HandleInput();
        }

        void HandleInput()
        {

            //Debug.Log(Input.GetJoystickNames()[0] + " is moved");
            float horizontalAxis2 = Input.GetAxis("Horizontal2");
            Turn(horizontalAxis2);
            float verticalAxis2 = Input.GetAxis("Vertical2");
            Thrust(verticalAxis2);

            float fireaxis = Input.GetAxis(_fireaxis);
            if (fireaxis != 0.0f)
            {
                Fire();
            }
        }

        private void Turn(float d)
        {
            //if (Mathf.Abs(d) < 0.02f) { return; }
            rb.AddTorque(d * -0.1f);
        }

        private void Thrust(float intensity)
        {
            //if (Mathf.Abs(intensity) < 0.02f) { return; }
            rb.AddRelativeForce(Vector2.up * intensity);
        }

        private void Fire()
        {
            float time = Time.time;
            if (time < _lastfire + FireCooldown)
            {
                return;
            }

            var pos = transform.position + transform.up * 0.7f;
            var rotation = transform.rotation;
            var velocity = transform.up * 4f;

            _lastfire = time;
            Object bullet = Resources.Load("Bullet");
            GameObject newBullet = (GameObject)Object.Instantiate(bullet, pos, rotation);
			newBullet.GetComponent<Bullet>().Initialize(this.gameObject, velocity);
        }*/
    }

}


