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
  Camera mainCamera;

  [SerializeField]
  float bulletSpeed = 10f;
  [SerializeField]
  Transform guntip;
  [SerializeField]
  Transform gun;
  // Start is called before the first frame update
  void Start()
  {
    mainCamera = Camera.main;
  }

  void OnDrawGizmos()
  {
    Vector3 screenCenter = Camera.main.ScreenToViewportPoint(new Vector3(.5f, .5f, 0));
    Gizmos.DrawSphere(screenCenter, 0.1f);
    Ray ray = new Ray(guntip.position, screenCenter);
    Gizmos.DrawLine(guntip.position, guntip.position + ray.direction);
  }
  // Update is called once per frame
  void Update()
  {

    if (Mouse.current.leftButton.wasPressedThisFrame)
    {
      RaycastHit hit;
      GameObject bullet = Instantiate(bulletPrefab, guntip.position, Quaternion.identity);//new Vector3(mainCamera.position.x + 0.5f * Mathf.Sin(x), mainCamera.position.y - 0.5f, mainCamera.position.z + 0.5f * Mathf.Sin(z)) , mainCamera.rotation);
      if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 100)) {
          bullet.transform.LookAt(hit.point);
      } else {
        bullet.transform.rotation = mainCamera.transform.rotation;
      }



      bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }
    //   // var x = mainCamera.transform.localEulerAngles.x * Mathf.PI / 180f;
    //   // var z = mainCamera.transform.localEulerAngles.x * Mathf.PI / 180f;
    //   Vector3 screenCenter = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width/2, Screen.height/2, 0));
    //   Ray ray = new Ray(guntip.position, screenCenter);
    //   GameObject bullet = Instantiate(bulletPrefab, guntip.position, Quaternion.Euler(ray.direction));//new Vector3(mainCamera.position.x + 0.5f * Mathf.Sin(x), mainCamera.position.y - 0.5f, mainCamera.position.z + 0.5f * Mathf.Sin(z)) , mainCamera.rotation);

  }
}

