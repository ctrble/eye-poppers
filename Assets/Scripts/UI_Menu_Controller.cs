using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI_Menu_Controller : MonoBehaviour {

	public GameObject creditsMenu;
	public GameObject controlsMenu;

	void Start () {
	
		StartCoroutine ("HideCredits");
	}

	void Update () {
	
		if (creditsMenu.activeSelf && Input.anyKeyDown)
			creditsMenu.SetActive (false);
	}

	void StartGame () {

//		SceneManager.LoadScene (0);
		StartCoroutine ("LoadGame");
	}

	void ShowControls () {

		controlsMenu.SetActive (true);
	}

	void HideControls () {

		controlsMenu.SetActive (false);
	}

	IEnumerator LoadGame () {
	
		yield return new WaitForSeconds (1.2f);
		SceneManager.LoadScene (1);
	}

	IEnumerator HideCredits () {
	
		yield return new WaitForSeconds (3f);
		creditsMenu.SetActive (false);
	}
}
