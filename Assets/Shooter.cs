using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// testing

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform mainCamera;

    [SerializeField]
    float bulletSpeed = 5f;

  // Start is called before the first frame update
  void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {  
        if(Mouse.current.leftButton.wasPressedThisFrame) {
            // var x = mainCamera.transform.localEulerAngles.x * Mathf.PI / 180f;
           // var z = mainCamera.transform.localEulerAngles.x * Mathf.PI / 180f;
            GameObject bullet = Instantiate(bulletPrefab, mainCamera.position + mainCamera.right*0.5f + mainCamera.up*-0.2f, mainCamera.rotation);//new Vector3(mainCamera.position.x + 0.5f * Mathf.Sin(x), mainCamera.position.y - 0.5f, mainCamera.position.z + 0.5f * Mathf.Sin(z)) , mainCamera.rotation);
            
            bullet.GetComponent<Rigidbody>().velocity = mainCamera.forward * bulletSpeed;
        }
    }
}
