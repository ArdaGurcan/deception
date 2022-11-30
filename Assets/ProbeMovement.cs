using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeMovement : MonoBehaviour
{

    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.position.y, player.position.z);

        float angularDifferenceBetweenRotations = Quaternion.Angle(transform.rotation, player.rotation);
        
        Quaternion rotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenRotations, Vector3.up);
		Vector3 newCameraDirection = rotationalDifference * player.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);


       
    }

}
