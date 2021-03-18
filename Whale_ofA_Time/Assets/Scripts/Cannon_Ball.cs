using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Ball : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Death") // if i hit a object with the tag death
            Destroy(gameObject); // destory this game object
    }

}


