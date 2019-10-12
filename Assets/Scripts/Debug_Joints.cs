using UnityEngine;
using System.Collections;

public class Debug_Joints : MonoBehaviour {

	void OnJointBreak2D (Joint2D brokenJoint) {
		Debug.Log ("A joint has just been broken!");
		Debug.Log ("The broken joint exerted a reaction force of " + brokenJoint.reactionForce);
//		Debug.Log ("The broken joint exerted a reaction torque of " + brokenJoint.reactionTorque);
	}
}
