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
    enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    Debug.Log(gameObject.name);
  }

  void Update()
  {
  }

  void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Enemy")) {
    //   Debug.Log(other.gameObject.name);

        Destroy(gameObject);
    }

    if(other.CompareTag("Player")) {
        SceneManager.LoadScene(0);
        // Debug.Log(other.gameObject.name);
        // Debug.Log("Player Shot");
        // Destroy(gameObject);
        // Destroy(other.gameObject);
    }
  }
}