using UnityEngine;
using System.Collections;

public class Eye_Controller : MonoBehaviour {

//	public AudioClip swingSound;
//	public AudioSource audioSource;
//	public float audioLevel; //0-1

	//the Input_Controller script
	public Input_Controller playerInput;

	public Rigidbody2D rigidBodyPupil;
	public Rigidbody2D rigidBodyWhite;

	public GameObject white;
	public GameObject pupil;

	public Transform leftSocketTransform;
	public Transform rightSocketTransform;
	public Transform currentFace;

	public float forceAmount;

	void OnEnable () {

//		audioSource = GetComponent<AudioSource> ();

		//get the Input_Controller script
		if (playerInput == null)
			playerInput = GetComponentInParent<Input_Controller> ();

		//get a white
		if (white == null)
			white = gameObject.transform.GetChild (0).GetChild (0).GetChild (0).GetChild (0).gameObject;

		//get a pupil
		if (pupil == null)
			pupil = gameObject.transform.GetChild (0).GetChild (0).GetChild (0).GetChild (0).GetChild (0).gameObject;

		//get the white's rigidBody
		if (rigidBodyWhite == null)
			rigidBodyWhite = white.GetComponent<Rigidbody2D> ();

		rigidBodyWhite.useAutoMass = true;

		//get the pupil's rigidBody
		if (rigidBodyPupil == null)
			rigidBodyPupil = pupil.GetComponent<Rigidbody2D> ();

		rigidBodyPupil.useAutoMass = true;
		rigidBodyPupil.angularDrag = 150;

		//get the face's sockets
		SocketLocator ();

		forceAmount = 12;
	}

	void Update () {

		//left eye inputs
		if (gameObject.name == "Left Eye")
			LeftEye ();

		//right eye inputs
		if (gameObject.name == "Right Eye")
			RightEye ();
		
		//eye positioning
		if (playerInput.FaceSwitchButton ())
			SocketLocator ();

//		Debug.Log (Mathf.Abs (rigidBodyWhite.velocity.x));
//		audioLevel = (Mathf.Clamp01 (Mathf.Abs (rigidBodyWhite.velocity.x)) + (Mathf.Abs (rigidBodyWhite.velocity.y)));
//		Debug.Log (audioLevel);
//		PlaySwingSound ();
	}

	void PlaySwingSound () {
//		audioLevel = (Mathf.Clamp01 (Mathf.Abs (rigidBodyWhite.velocity.x)) + (Mathf.Abs (rigidBodyWhite.velocity.y)));
//		int randomSwing = Random.Range (0, swingSounds.Length);
//		AudioClip chosenSwing = swingSound;
//		audioSource.clip = chosenSwing;
//		audioSource.Play();
	}

	void SocketLocator() {

		//find the face sibling
		foreach(Transform child in gameObject.transform.parent.parent){
			if(child.CompareTag("Face"))
				currentFace = child.gameObject.transform;
		}

		//find the face's sockets
		foreach(Transform child in currentFace){
			if(child.CompareTag("LeftSocket"))
				leftSocketTransform = child.gameObject.transform;
			else if(child.CompareTag("RightSocket"))
				rightSocketTransform = child.gameObject.transform;
		}

		//move the eye to the socket location
		if (gameObject.name == "Left Eye")
			gameObject.transform.position = leftSocketTransform.position;
		if (gameObject.name == "Right Eye")
			gameObject.transform.position = rightSocketTransform.position;
	}

	void LeftEye () {
		
		if(playerInput.Button1()) {
//			Debug.Log("q");
			AddUpForce ();
		}

		if(playerInput.Button2()) {
//			Debug.Log("w");
			AddRightForce ();
		}

		if(playerInput.Button3()) {
//			Debug.Log("a");
			AddLeftForce ();
		}

		if(playerInput.Button4()) {
//			Debug.Log("s");
			AddDownForce ();
		}
	}

	void RightEye () {

		if(playerInput.Button5()) {
//			Debug.Log("o");
			AddUpForce ();
		}

		if(playerInput.Button6()) {
//			Debug.Log("p");
			AddRightForce ();
		}

		if(playerInput.Button7()) {
//			Debug.Log("k");
			AddLeftForce ();
		}

		if(playerInput.Button8()) {
//			Debug.Log("l");
			AddDownForce ();
		}
	}

	void AddUpForce () {
		rigidBodyWhite.AddForce (transform.up * forceAmount);
		rigidBodyPupil.AddForce (transform.up * forceAmount);
		AddRotation ();
	}

	void AddRightForce () {
		rigidBodyWhite.AddForce (transform.right * forceAmount);
		rigidBodyPupil.AddForce (transform.right * forceAmount);
		AddRotation ();
	}

	void AddDownForce () {
		rigidBodyWhite.AddForce (-transform.up * forceAmount);
		rigidBodyPupil.AddForce (-transform.up * forceAmount);
		AddRotation ();
	}

	void AddLeftForce () {
		rigidBodyWhite.AddForce (-transform.right * forceAmount);
		rigidBodyPupil.AddForce (-transform.right * forceAmount);
		AddRotation ();
	}


	void AddRotation () {

		rigidBodyWhite.AddTorque (-(rigidBodyWhite.velocity.x + rigidBodyWhite.velocity.y));
	}
}
