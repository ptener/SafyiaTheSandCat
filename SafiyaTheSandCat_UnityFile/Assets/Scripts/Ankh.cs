using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ankh : MonoBehaviour {

	private PlayerControllerScript playerScript;

	void Start(){
		playerScript = GameObject.Find ("Player").GetComponent<PlayerControllerScript> ();
	}

	void OnTriggerEnter2D (Collider2D player) {
		if (player.gameObject.name == "Player") {
			playerScript.hasAnkh = true;
			Destroy (this.gameObject);
		}
	}

}
