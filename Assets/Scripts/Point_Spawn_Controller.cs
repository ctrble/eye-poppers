using UnityEngine;
using System.Collections;

public class Point_Spawn_Controller : MonoBehaviour {

	//the eye to drop, must match the eye you just lost
	public GameObject eyeball;

	void OnTriggerEnter2D(Collider2D other) {

		//when an eye falls, toss one in the jar
		if (other.tag == "Respawn")
			DropEye();
	}

	void DropEye() {
	
		//spawn a tiny eye above the jar
		Vector3 eyeSpawnPoint = new Vector3(Random.Range(-6.45f, -6.55f), Random.Range(7f, 8f), 0);
		Instantiate (eyeball, eyeSpawnPoint, Quaternion.identity);
		StartCoroutine ("DiscardEye");
	}

	IEnumerator DiscardEye() {
	
		//stop that ball from falling forever
		yield return new WaitForSeconds (0f);
		gameObject.SetActive (false);
	}
}
