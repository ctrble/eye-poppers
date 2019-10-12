using UnityEngine;
using System.Collections;

public class UI_Points_Controller : MonoBehaviour {

	//get the Sprite Renderer
	public SpriteRenderer spriteRenderer;

	//match the sprite to the number of points
	public Sprite[] pointsUISprites;
	public int points;

	//the Game_Controller script
	public Game_Controller gameController;

	void OnEnable() {

		//get the Sprite Renderer
		if (spriteRenderer == null)
			spriteRenderer = GetComponent<SpriteRenderer> ();

		//get the Game_Controller script
		if (gameController == null)
			gameController = transform.parent.GetComponent<Game_Controller> ();

		//subscription to the eye drop
		Game_Controller.DroppedEye += UpdateUI;
	
		//null
		points = 0;

		//be under the eyes
		spriteRenderer.sortingOrder = 0;

		UpdateUI ();
	}

	void OnDisable() {

		//unsubscribe to the nerve break, no memory leaks
		Game_Controller.DroppedEye -= UpdateUI;
	}

	void UpdateUI() {

		//we got a point!
		StartCoroutine ("MorePoints");
	}

	IEnumerator MorePoints() {

		//cause falling isn't instant
		yield return new WaitForSecondsRealtime (gameController.eyeDropDelay);

		//when we win, move above the face
		if (gameController.totalPoints == 10)
			spriteRenderer.sortingOrder = 4;

		//update the UI
		spriteRenderer.sprite = pointsUISprites[gameController.totalPoints];
	}
}
