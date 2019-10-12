using UnityEngine;
using System.Collections;

public class Eye_Pop_Controller : MonoBehaviour {

	//monitor speed, if fast enough increase eye size

	public Vector3 startSize;
	public Vector3 maxSize;
	public Vector3 settleSize;

	void OnEnable() {

		startSize = new Vector3 (0.75f, 0.75f, 0.75f);
		maxSize = new Vector3 (1.25f, 1.25f, 1.25f);
		settleSize = new Vector3 (1, 1, 1);

		transform.localScale = startSize;
	}

	IEnumerator EyePop() {

		float scaleDuration = 0.25f; 

		for(float t = 0; t < 1; t += Time.deltaTime / (scaleDuration / 2 ) )
		{
			transform.localScale = Vector3.Lerp(startSize, maxSize, t);
			yield return null;
		}

		for(float t = 0; t < 1; t += Time.deltaTime / scaleDuration )
		{
			transform.localScale = Vector3.Lerp(maxSize, settleSize, t);
			yield return null;
		}
	}
}
