using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start(){
		gameObject.GetComponent<Text>().color = player.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update(){
		gameObject.GetComponent<Text>().text = ""+player.GetComponent<player>().Score;
	}
}
