using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorCamera : MonoBehaviour
{
    public Transform player;
	public Transform mirror;
	
	// Update is called once per frame
	void Update () {
		Vector3 playerOffsetFromMirror = player.position - mirror.position;
		// transform.position = mirror.position + playerOffsetFromMirror;
        transform.position = new Vector3(mirror.position.x, player.position.y, player.position.z);

		float angularDifferenceBetweenRotations = Quaternion.Angle(mirror.rotation, player.rotation);

		Quaternion mirrorRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenRotations, Vector3.up);
		Vector3 newCameraDirection = mirrorRotationalDifference * player.forward;
		// transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
