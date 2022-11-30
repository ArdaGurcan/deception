using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    Animator door_Animator;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contact with " + other.tag + " " + other.name);
        
        // if the door collides with Player
        if (other.CompareTag("Player")) {
            door_Animator = gameObject.GetComponent<Animator>(); 
            door_Animator.SetTrigger("PlayerIsNear");
        }

    }

     void OnTriggerExit(Collider other) 
     {
        if (other.CompareTag("Player")) {
            door_Animator = gameObject.GetComponent<Animator>(); 
            door_Animator.SetTrigger("PlayerIsOut");
        }
     }
  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
