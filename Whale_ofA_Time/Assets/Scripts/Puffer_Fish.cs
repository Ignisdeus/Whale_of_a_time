using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puffer_Fish : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
     
        if(other.gameObject.tag == "Ball")
        {
            anim.SetTrigger("Puff"); 
        }
    }
}
