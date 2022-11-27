using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  Transform mainCamera;
  Animator enemy_Animator;

  void Start()
  {
    mainCamera = Camera.main.transform;
    transform.Rotate(90, 0, 0);
  }

  void Update()
  {
    if (Vector3.SqrMagnitude(mainCamera.position - transform.position) > 10000)
    {
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Hit " + other.tag + " " + other.name);
    // if the bullet hits an enemy
    if (other.CompareTag("Enemy")) {
      enemy_Animator = other.gameObject.GetComponent<Animator>(); 
      // change animation to Death
      enemy_Animator.SetTrigger("shotTrigger");
      Destroy(gameObject);
    }
    if (!other.CompareTag("Player"))
      Destroy(gameObject);

    // if(other.CompareTag("Enemy")) {
    //   Destroy(gameObject);
    //   Destroy(other.gameObject);
    // }
  }
}
