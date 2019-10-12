using UnityEngine;
using System.Collections;

public class Nerve_Controller : MonoBehaviour {

	//set up a delegate for stuff to subscribe to
	public delegate void SeparationAction();
	public static event SeparationAction NerveSeparation;

	//set up a delegate for stuff to subscribe to
	public delegate void FirstSeparationAction();
	public static event FirstSeparationAction FirstNerveSeparation;

	//set up the nerves
	public GameObject connectionSelf;
	public GameObject connectionNext;
	public SpringJoint2D springJoint;
	public int lengthOfLineRenderer = 2;
	public bool isEye;

	//still all in one piece?
	public bool stillConnected;

	void OnEnable() {

		if (gameObject.name == "Whites") {
		
			isEye = true;
			//get yourself
			if (connectionSelf == null)
				connectionSelf = gameObject;

			//get the parent
			if (connectionNext == null)
				connectionNext = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
		} else {
		
			isEye = false;
			//get yourself
			if (connectionSelf == null)
				connectionSelf = gameObject;

			//get the parent
			if (connectionNext == null)
				connectionNext = gameObject.transform.GetChild (0).gameObject;
		}

		//get the Input_Controller script
		if (springJoint == null)
			springJoint = GetComponent<SpringJoint2D> ();

		//back in one piece
		stillConnected = true;
	}


	void Update() {

		if (stillConnected == true) {

			//draw a line across the nerves
			LineRenderer lineRenderer = GetComponent<LineRenderer>();
			var points = new Vector3[lengthOfLineRenderer];
			points[0] = new Vector3(connectionSelf.transform.position.x, connectionSelf.transform.position.y, connectionSelf.transform.position.z);
			points[1] = new Vector3(connectionNext.transform.position.x, connectionNext.transform.position.y, connectionNext.transform.position.z);
			lineRenderer.sortingOrder = 0;
			lineRenderer.SetPositions(points);
		}

		if (stillConnected == false) {

			//lost an eye, stop drawing that bit of nerve
			LineRenderer lineRenderer = GetComponent<LineRenderer>();
			lineRenderer.enabled = false;
		}
	}

	void OnJointBreak2D (Joint2D brokenJoint) {

//		Debug.Log(gameObject.name + " broke!");

		if (isEye == false) {
		
			//separate and hide broken nerve
			stillConnected = false;
			springJoint.enabled = false;

			//event call
			NerveSeparation();
		} else if (isEye == true) {

			//separate and hide broken nerve
			stillConnected = false;
			springJoint.enabled = false;

			BroadcastMessage ("EyePop");
			//event call
			FirstNerveSeparation();
		}
	}
}
