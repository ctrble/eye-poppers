using UnityEngine;
using System.Collections;

public class Input_Controller : MonoBehaviour {

	/*

SETUP

Attach this script to each player GameObject.
The player objects should be named "Player 1", "Player 2", and so forth.

Reference this script from other scripts with:

//the Input_Controller script
public Input_Controller playerInput;

		void OnEnable () {

			//get the Input_Controller script
			if (playerInput == null)
				playerInput = GetComponent<Input_Controller> ();
		}

		void Update () {

			//check the button bools
			if(playerInput.Button1())
				//do some stuff
		}

*/

	public GameObject pauseUI;

	public bool PauseButton () {

		if (Input.GetKeyDown (KeyCode.Escape)) {

			return true;
		} else {
			return false;
		}
	}

	public bool FaceSwitchButton () {

		if (Input.GetKeyDown (KeyCode.T) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool EyeSwitchButton () {

		if (Input.GetKeyDown (KeyCode.G) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool MouthSwitchButton () {

		if (Input.GetKeyDown (KeyCode.B) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button1 () {

		if (Input.GetKey (KeyCode.Q) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button2 () {

		if (Input.GetKey (KeyCode.W) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button3 () {

		if (Input.GetKey (KeyCode.A) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button4 () {

		if (Input.GetKey (KeyCode.S) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button5 () {

		if (Input.GetKey (KeyCode.O) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button6 () {

		if (Input.GetKey (KeyCode.P) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button7 () {

		if (Input.GetKey (KeyCode.K) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}

	public bool Button8 () {

		if (Input.GetKey (KeyCode.L) && !pauseUI.activeInHierarchy) {

			return true;
		} else {
			return false;
		}
	}
}
