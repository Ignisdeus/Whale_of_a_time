using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_Screen_Master : MonoBehaviour
{

    public KeyCode reset;
    void Update()
    {
        if(Input.GetKeyDown(reset))
        {
            // reset the level 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
