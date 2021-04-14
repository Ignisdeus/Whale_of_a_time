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
    public float forceToAdd = 500f;
    public bool isRight = false; 
    private void OnCollisionEnter2D(Collision2D other)
    {
     
        if(other.gameObject.tag == "Ball")
        {
            if(isRight)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceToAdd);
            }
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceToAdd);
            }
            anim.SetTrigger("Puff"); 
        }
    }
}
