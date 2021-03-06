using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale_Movement : MonoBehaviour
{
    void Start()
    {
        
    }

    public float speed = 5f; // Whale movement speed 
    public float minX, maxX; // min and max movement constraint 
    void Update()
    {
        // get input from Horizontal movement 
        float hz = Input.GetAxisRaw("Horizontal");
        // move the whale 
        transform.Translate(Vector2.right * hz * (speed * Time.deltaTime));
        // limits on the whales movement 
        if(transform.position.x < minX){
            transform.position = new Vector2(minX, transform.position.y); 
        }
        if(transform.position.x > maxX){
            transform.position = new Vector2(maxX, transform.position.y); 
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        	// if I collide with the ball display debug. 
        if(other.gameObject.tag =="Ball"){
            Debug.Log("Hit the Ball");
        }
    }
}

