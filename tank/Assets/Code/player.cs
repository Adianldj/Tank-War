using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class player : MonoBehaviour
    {
		//Game play parameters for easy mechanic experimentation

		//which player this is
		[Range(1,2)]
		public int playerNum;

		[Header("Shooting")]
		public float bulletSpeed = 4;//the speed of the bullet fired
		public float FireCooldown = 1f;//controls how fast the player can shoot

		[Header("Movement")]
		public float turnSpeed = 0.1f;
		public float thrustStrength = 1f;
		public float maxSpeed = -1;//-1 for unlimited
		public float maxTurnSpeed = -1;//-1 for unlimited

		//how quickly the player slows down (from 0-1, with higher values slowing quicker (though you *could* set it to a weird value I guess))
		[Range(0,1)]
		public float drag = 0;

		//Internal logic variables

		private int score;
		public int Score {
			get{return score;}
			private set{score = value;}
		}

		//stores the rigid body component for convenience
        private Rigidbody2D rb;

		//counter specifying if the player is in hitstun
		private int hitstun;
		private const int hitstunLength = 60/2;//in frames

		//internal logic for enforcing the fire speed
        private float _lastfire;

		//the input axes, stored for convenience (and cause they're different for player 1 and 2)
		private string fireAxis;
		private string turnAxis;
        private string thrustAxis;

        void Start(){
			//get some data for later convenience

            rb = gameObject.GetComponent<Rigidbody2D>();

			fireAxis = Platform.GetFireAxis()+playerNum;
			turnAxis = "Horizontal"+playerNum;
			thrustAxis = "Vertical"+playerNum;
        }

        //Since we're doing movement things, it's probably best to do that in fixed update
        internal void FixedUpdate(){

			if(!inHitstun()){
				//Do the movement!
				Turn(Input.GetAxis(turnAxis));
				Thrust(Input.GetAxis(thrustAxis));

				//Clamp the movement if above the max speed

				//using squares for that (completely irrelevant) performance boost
				if(maxSpeed >= 0 && rb.velocity.sqrMagnitude > maxSpeed * maxSpeed){
					//scale down the velocity to the maximum speed
					rb.velocity = rb.velocity * (maxSpeed / rb.velocity.magnitude);
				}

				if(maxTurnSpeed >= 0 && Mathf.Abs(rb.angularVelocity) > maxTurnSpeed){
					//set the agnular velocity to the maximum speed in the current turning direction
					rb.angularVelocity = Mathf.Sign(rb.angularVelocity) * maxTurnSpeed;
				}


				//Shoot Things!
				float fireaxis = Input.GetAxis(fireAxis);
				if(fireaxis != 0.0f){
					Fire ();
				}
			}else{
				hitstun--;
			}

        }

        private void Turn(float d){
			if(Mathf.Abs(d) < 0.2f){
				//apply drag if there's no turning going on
				rb.angularVelocity *= (1-drag);
			}else{
				rb.AddTorque(d * -turnSpeed * rb.inertia);
			}
        }

        private void Thrust(float d){
			if(Mathf.Abs(d) < 0.2f){
				//apply drag if there's no turning going on
				rb.velocity *= (1-drag);
			}else{
				rb.AddRelativeForce(Vector2.up * d * thrustStrength * rb.mass);
			}
        }

        private void Fire(){
			//don't fire if this player has fired within the span of the cooldown
            float time = Time.time;
            if(time < _lastfire + FireCooldown){
                return;
            }

			//keep track of when the player fired
			_lastfire = time;

			//get the transform params for the new bullet
			var pos = transform.position + transform.up * transform.localScale.y * 0.7f;
            var rotation = transform.rotation;
            var velocity = transform.up * bulletSpeed;

            //create the bullet with a prefab
            Object bullet = Resources.Load("Bullet");
			GameObject newBullet = (GameObject) GameObject.Instantiate(bullet, pos, rotation, GameObject.Find("Bullets").transform);
			newBullet.GetComponent<Bullet>().Initialize(this.gameObject, velocity);
        }

		public void hit(Vector2 cp, Vector2 v){

			//spin. weeeeeeeeeeeeeeeee
			if(maxTurnSpeed<0){
				rb.AddForceAtPosition(v*(0.05f/v.magnitude), gameObject.transform.worldToLocalMatrix*cp, ForceMode2D.Impulse);
			}else{
				rb.AddForce(v*(3f/v.magnitude), ForceMode2D.Impulse);
				rb.AddTorque(5, ForceMode2D.Impulse);
			}
			//enter hit state
			hitstun = hitstunLength;

		}

		public bool inHitstun(){
			return hitstun > 0;
		}

		public void addScore(int score){
			Score += score;
		}

    }

  /*public class Gun : MonoBehaviour
    {
        private const float FireCooldown = 1f;
        private float _lastfire;

        public void Fire()
        {
            float time = Time.time;
            if (time < _lastfire + FireCooldown)
            {
                return;
            }

            _lastfire = time;
            //.ForceSpawn(
            //transform.position + transform.up * 0.7f,
            //transform.rotation,
            //transform.up * 4f,
            //time + Bullet.Lifetime);
        }
    }*/
}