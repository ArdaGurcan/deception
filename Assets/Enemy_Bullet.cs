using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Bullet : MonoBehaviour
{
    Transform enemy;
  void Start()
  {
    transform.Rotate(90, 0, 0);
    if(GameObject.FindGameObjectWithTag("Enemy") == null) {
      enemy = null;
    } else
      enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

    Debug.Log(gameObject.name);
  }

  void Update()
  {
    if (enemy == null || Vector3.SqrMagnitude(enemy.position - transform.position) > 10000)
    {
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Enemy")) {
        Destroy(gameObject);
    }

    if(other.CompareTag("Player")) {
        SceneManager.LoadScene(0);
    }
  }
}