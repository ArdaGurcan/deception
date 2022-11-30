using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEffect : MonoBehaviour
{
  [SerializeField]
  GameObject mirror;

  [SerializeField]
  GameObject playerCam;

  private Vector3 reflect;
  private Transform player;

  private Bounds mirrorBound;
    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.transform;
        mirrorBound = mirror.GetComponent<Renderer>().bounds;
        gameObject.transform.position = new Vector3(
            mirror.transform.position.x, 
            playerCam.transform.position.y, 
            mirror.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 indirection = transform.position - player.transform.position;
        reflect = Vector3.Reflect(indirection, Vector3.forward * 1);
        transform.rotation = Quaternion.LookRotation(reflect);
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, reflect);
    }
}
