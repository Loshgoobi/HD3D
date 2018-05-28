using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	public void Play() {
        Debug.Log("Clicked");
		SceneManager.LoadScene ("t6"); //à changer avec le nom de la scene de jeu
	}
}
