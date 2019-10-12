using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye_Audio_Controller : MonoBehaviour {

	public AudioClip[] bupSounds;

	public AudioSource audioSource;

	void OnEnable () {

		audioSource = GetComponent<AudioSource> ();
	}

	void PlayBupSound () {

		int randomBup = Random.Range (0, bupSounds.Length);
		AudioClip chosenBup = bupSounds [randomBup];
		audioSource.PlayOneShot(chosenBup, 0.5f);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		
		PlayBupSound();
	}
}
