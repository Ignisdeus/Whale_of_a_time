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
    public float jumpForce = 250f;// how hard / high I jump 
      
    public KeyCode jump; // pick a key  
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
        // if I hit the jump key and I am grounded jump.
        if(Input.GetKeyDown(jump) && grounded == true){
            grounded = false; 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        // if I collide with the ball display debug. 
        if(other.gameObject.tag =="Ball"){
            Debug.Log("Hit the Ball");
        }
    }
    // bool for checking if this game object is grounded 
    public bool grounded = false; 
    void OnTriggerStay2D(Collider2D other){
        // if im on the ground im grounded
        if(other.gameObject.tag =="Ground"){
            grounded = true; 
        }
    }
}

