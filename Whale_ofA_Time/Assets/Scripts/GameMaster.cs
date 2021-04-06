using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public KeyCode reset;
    public GameObject endScreen; 

    private void Update()
    {
        if(Input.GetKeyDown(reset) && endScreen.activeInHierarchy) {
            // reset the level 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
