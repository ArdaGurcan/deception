using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//dbas;bsa;odaoid

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
            GameObject bullet = Instantiate(bulletPrefab, mainCamera.position, mainCamera.rotation);
            bullet.GetComponent<Rigidbody>().velocity = mainCamera.forward * bulletSpeed;
        }
    }
}
