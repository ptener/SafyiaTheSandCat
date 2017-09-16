using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuSceen : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D player){
		if (player.gameObject.name == "Player") {
			SceneManager.LoadScene ("Title_Screen");
		}
	}
}
