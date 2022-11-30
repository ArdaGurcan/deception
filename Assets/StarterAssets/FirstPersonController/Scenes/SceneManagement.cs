using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneManagement : MonoBehaviour
{
  [SerializeField]
  Animator gun;

  void Update()
  {
    if (Keyboard.current.qKey.wasPressedThisFrame && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    {
      gun.SetTrigger("die");
      StartCoroutine("LoadScene");
    }
  }

  IEnumerator LoadScene()
  {
    yield return new WaitForSeconds(2);
    SceneManager.LoadScene(0);
  }


}
