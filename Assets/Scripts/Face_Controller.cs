using UnityEngine;
using System.Collections;

public class Face_Controller : MonoBehaviour {

	//instantiate some face, socket, and mouth prefabs
	//switch between prefabs on keycode for a new look

	//the Input_Controller script
	public Input_Controller playerInput;

	//all dem face bits
	public GameObject[] faces;
	public GameObject[] eyes;
	public GameObject[] mouths;

	//current face and previous face
	public int selectedFace;
	public GameObject oldFace;

	//current eyes and previous eyes
	public int selectedEyes;
	public GameObject oldEyes;

	//current mouth and previous mouth
	public int selectedMouth;
	public GameObject oldMouth;

	void OnEnable() {

		//get the Input_Controller script
		if (playerInput == null)
			playerInput = GetComponentInParent<Input_Controller> ();
	
		//build a face workshop!
		CreateFeatures ();
	}

	void OnDisable () {
	
		//remove features
		Destroy (oldFace);
		Destroy (oldEyes);
		Destroy (oldMouth);
	}

	void CreateFeatures() {

		//make a face!
		ChooseFace();
		ChooseEyes();
		ChooseMouth();

		//update references to the chosen face bits
		GetKids ();
	}

	void ChooseFace() {

		//pick a random face
		selectedFace = Random.Range (0, faces.Length);
		Instantiate (faces [selectedFace], gameObject.transform);
	}

	void ChooseEyes() {

		//pick random eye sockets (with eyes duh)
		selectedEyes = Random.Range (0, eyes.Length);
		Instantiate (eyes [selectedEyes], gameObject.transform);
	}

	void ChooseMouth() {

		//pick a random mouth
		selectedMouth = Random.Range (0, mouths.Length);
		Instantiate (mouths [selectedMouth], gameObject.transform);
	}

	void Update() {
	
		//yay we hit a key for new face bits
		ChangeFace ();
		ChangeEyes ();
		ChangeMouth ();
	}

	void ChangeFace() {

		if (playerInput.FaceSwitchButton ()) {

			//next in array
			selectedFace = selectedFace + 1;
			if (selectedFace >= faces.Length)
				selectedFace = 0;

			//out with the old, in with the new
			Destroy (oldFace);
			Instantiate (faces[selectedFace], gameObject.transform);

			//update references to the chosen face bits
			GetKids ();
		}
	}

	void ChangeEyes() {

		if (playerInput.EyeSwitchButton ()) {

			//next in array
			selectedEyes = selectedEyes + 1;
			if (selectedEyes >= eyes.Length)
				selectedEyes = 0;

			//out with the old, in with the new
			Destroy (oldEyes);
			Instantiate (eyes[selectedEyes], gameObject.transform);

			//update references to the chosen face bits
			GetKids ();
		}
	}

	void ChangeMouth() {

		if (playerInput.MouthSwitchButton ()) {

			//next in array
			selectedMouth = selectedMouth + 1;
			if (selectedMouth >= mouths.Length)
				selectedMouth = 0;

			//out with the old, in with the new
			Destroy (oldMouth);
			Instantiate (mouths[selectedMouth], gameObject.transform);

			//update references to the chosen face bits
			GetKids ();
		}
	}

	void GetKids() {
	
		//update references to the chosen face bits
		foreach(Transform child in transform){
			if(child.CompareTag("Face"))
				oldFace = child.gameObject;
		}

		foreach(Transform child in transform){
			if(child.CompareTag("Eyes"))
				oldEyes = child.gameObject;
		}

		foreach(Transform child in transform){
			if(child.CompareTag("Mouth"))
				oldMouth = child.gameObject;
		}
	}
}
