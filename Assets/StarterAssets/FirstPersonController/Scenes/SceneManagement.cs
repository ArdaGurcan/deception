using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneManagement : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.qKey.wasPressedThisFrame && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            SceneManager.LoadScene(0);
        }
    }
}
