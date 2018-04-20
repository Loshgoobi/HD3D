using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	public void Play() {
		SceneManager.LoadScene (1, LoadSceneMode.Single); //à changer avec le nom de la scene de jeu
	}
}
