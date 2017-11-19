using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Bullet : MonoBehaviour
    {

		private GameObject owner;

		private GameObject EXPLOSION;

		private void start(){
			EXPLOSION = Resources.Load<GameObject>("EXPLOSION");
		}

        internal void Initialize(GameObject owner, Vector2 velocity){
            //keep track of which player shot this bullet
			this.owner = owner;

			gameObject.transform.localScale = owner.transform.localScale * 0.2f;

			gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
			gameObject.GetComponent<SpriteRenderer>().color = owner.GetComponent<SpriteRenderer>().color;
        }

		void OnTriggerEnter2D(Collider2D other){

			if(other.gameObject.GetComponent<player>() != null || other.gameObject.GetComponent<Bullet>() != null){
				//create an explosion
				GameObject splosion = Object.Instantiate(Resources.Load<GameObject>("EXPLOSION"), transform.position, Quaternion.identity);
				//scale it to not be overly big or overly small compared to the player it hit
				splosion.transform.localScale = 0.4f * other.gameObject.transform.localScale.magnitude * new Vector3(1,1,1);
			}


			//if it has hit a player
			if(other.gameObject.GetComponent<player>() != null){

				//notify the player to say it's been it
				other.gameObject.GetComponent<player>().hit(gameObject.transform.position, gameObject.GetComponent<Rigidbody2D>().velocity);

				//adjust scores
				owner.GetComponent<player>().addScore(owner==other.gameObject ? -1 : 2);

			}

			//destroy the bullet if it hits anything
			Destroy (gameObject);

		}

    }
}