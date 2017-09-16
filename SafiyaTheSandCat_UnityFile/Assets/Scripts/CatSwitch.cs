using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSwitch : MonoBehaviour {

	public GameObject throwingSand;
	private SpriteRenderer catSR;
	public Sprite activeCat;

	void Start () {
		catSR = GetComponent<SpriteRenderer> ();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D player) {
		if(player.gameObject.name == "Player"){
			for (int i = 11; i < 28; i++) {
				GameObject flyingSand = (GameObject)Instantiate (throwingSand, transform.position + new Vector3 (i, 10, 0), Quaternion.identity);
			}
			catSR.sprite = activeCat;
		}

	
	}
}
