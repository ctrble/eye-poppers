using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Audio_Controller : MonoBehaviour {

	public AudioClip[] snapSounds;


	public AudioSource audioSource;

	void OnEnable () {
		
		audioSource = GetComponent<AudioSource>();

		//subscription to the nerve break
		Nerve_Controller.FirstNerveSeparation += PlaySnapSound;

		//subscription to the nerve break
		Nerve_Controller.NerveSeparation += PlaySnapSound;
	}

	void PlaySnapSound () {
	
		int randomSnap = Random.Range (0, snapSounds.Length);
		AudioClip chosenSnap = snapSounds [randomSnap];
		audioSource.PlayOneShot(chosenSnap, 0.5f);
	}

	void OnDisable() {

		//subscription to the nerve break
		Nerve_Controller.FirstNerveSeparation -= PlaySnapSound;

		//subscription to the nerve break
		Nerve_Controller.NerveSeparation -= PlaySnapSound;
	}
}
