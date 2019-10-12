using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause_Game_Controller : MonoBehaviour {

	void OnEnable () {
	
		Time.timeScale = 0F;
	}

	void OnDisable () {

		Time.timeScale = 1F;
	}

	void Quit () {

		SceneManager.LoadScene (0);
	}

	void Restart () {
	
		Scene loadedLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (loadedLevel.buildIndex);
	}
}
