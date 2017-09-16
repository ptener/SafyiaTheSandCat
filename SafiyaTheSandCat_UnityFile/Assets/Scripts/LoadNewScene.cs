using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D player){
		if (player.gameObject.name == "Player") {
			SceneManager.LoadScene ("Indoor_Level");
		}
	}
}
