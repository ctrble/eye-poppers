using UnityEngine;
using System.Collections;

public class Game_Controller : MonoBehaviour {

	//on win, rebuild new face
	//auto selects random eyes, mouth, and face
	//can override to another piece

	//set up a delegate for stuff to subscribe to
	public delegate void GotPointAction();
	public static event GotPointAction DroppedEye;

	//the Input_Controller script
	public Input_Controller playerInput;

	//yo it's the player
	public GameObject player;

	public GameObject pauseUI;

	//points!
	public int currentPoints;
	public int totalPoints;

	//those eyes take a moment to fall offscreen then onscreen
	public float eyeDropDelay;

	void OnEnable(){

		//get the Input_Controller script
		if (playerInput == null)
			playerInput = player.GetComponent<Input_Controller> ();

		//new face, no points yet
		currentPoints = 0;
		totalPoints = 0;

		//this ain't instant
		eyeDropDelay = 2f;

		//subscription to the nerve break
		Nerve_Controller.NerveSeparation += AddPoint;
	}

	void OnDisable() {

		//unsubscribe to the nerve break, no memory leaks
		Nerve_Controller.NerveSeparation -= AddPoint;
	}

	void Update() {
	
		if (playerInput.PauseButton ()) {
		
			//put up pause menu
			if (pauseUI.activeSelf == true)
				pauseUI.SetActive (false);
			else
				pauseUI.SetActive (true);
		}
	}

	void AddPoint() {

		//+1
		currentPoints = currentPoints + 1;
		totalPoints = totalPoints + 1;

		//maybe all the eyes are gone?
		StartCoroutine ("NewFace");
	}

	IEnumerator NewFace() {

		//event call
		DroppedEye ();

		//lost both current eyes
		if (currentPoints == 2) {

			//yup, both eyes gone, time to reset
			yield return new WaitForSecondsRealtime (eyeDropDelay);
			player.SetActive (false);
			yield return new WaitForSecondsRealtime (0.5f);
			player.SetActive (true);
			currentPoints = 0;
		}

		else if (currentPoints < 2) {

			//nah, we good
			yield return null;
		}

		if (totalPoints == 10) {

			//yup, we win!
			yield return new WaitForSecondsRealtime (eyeDropDelay);
			totalPoints = 0;

			//put up pause menu
			pauseUI.SetActive (true);
		}

		if (totalPoints < 10) {

			//nah, we good
			yield return null;
		}
	}
}
