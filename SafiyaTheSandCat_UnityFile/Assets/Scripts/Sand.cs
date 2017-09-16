using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour {
	private Rigidbody2D sandRigi;
	private PlayerControllerScript playerScript;
	public GameObject sittingSand;

	// Use this for initialization
	void Start () {
		sandRigi = GetComponent<Rigidbody2D> ();
		playerScript = GameObject.Find ("Player").GetComponent<PlayerControllerScript> ();



	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D surface){
		if(surface.gameObject.name != "Player" && surface.gameObject.tag != "Sand"){
			Destroy (this.gameObject);
			GameObject stillSand = (GameObject)Instantiate (sittingSand, transform.position, Quaternion.identity);
		}
	}

}
