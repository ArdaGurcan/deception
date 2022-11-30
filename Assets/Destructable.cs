using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destroyedVersion;
   void OnTriggerEnter(Collider other)
   {
        Debug.Log("hit!");
        if(!other.CompareTag("Player")){
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    
   }
}
