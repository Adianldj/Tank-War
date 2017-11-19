using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPLOSION : MonoBehaviour {

	public float animationSpeed;

	private Sprite[] sprites;

	private int spriteNumber;
	private float lastFrame;

	void Start(){
		//start at the last sprite in the sheet
		spriteNumber = 3;

		//load the sprite sheet
		sprites = Resources.LoadAll<Sprite>("Explosion");

		//start the first frame
		lastFrame = Time.time;
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteNumber];
	}

	void Update(){

		float time = Time.time;
		if(time>=lastFrame+(1.0f/animationSpeed)){
			spriteNumber--;
			lastFrame = time;

			//destroy the object if the animation is over
			if(spriteNumber < 0){
				GameObject.Destroy(gameObject);
				return;
			}

			//update the sprite to the current frame
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteNumber];

		}
	}
}
