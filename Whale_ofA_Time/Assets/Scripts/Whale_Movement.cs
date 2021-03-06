using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Whale_Movement : MonoBehaviour
{
    Vector2 startingPos; // my starting posision 
    int lives = 2; // number of remaning Lives
    public GameObject[] livesObjects; // a list of game objects 
    float scaleOnX; // to hold the x scale value
    void Start()
    {
        scaleOnX = transform.localScale.x; 
        startingPos = transform.position; // storing my starting posision
        scoreText.text = score.ToString(); // display score to screen
    }

    public float speed = 5f; // Whale movement speed 
    public float minX, maxX; // min and max movement constraint 
    public float jumpForce = 250f;// how hard / high I jump 
      
    public KeyCode jump; // pick a key  
    void Update()
    {
        // get input from Horizontal movement 
        float hz = Input.GetAxisRaw("Horizontal");
        if(hz <= -0.1f)
        {
            transform.localScale = new Vector3(-scaleOnX, transform.localScale.y, transform.localScale.z);
        }
        if(hz >= 0.1f)
        {
            transform.localScale = new Vector3(scaleOnX, transform.localScale.y, transform.localScale.z);
        }
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

    void OnCollisionEnter2D(Collision2D other){
        // if I collide with the ball display debug. 
        if(other.gameObject.tag =="Ball"){
            Destroy(other.gameObject);
            lives--; // reduce lives by one
            UpdateLives();
            transform.position = startingPos; // reset my posision  
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Win")
        {
            transform.position = startingPos; // reset my posision
            AddScore();
        }
    }
    int score = 0;
    public Text scoreText; 
    void AddScore()
    {
        score += 100;// adds 100 to the score
        scoreText.text = score.ToString(); // display score to screen 
    }
    public GameObject gameOverScreen; 
    void UpdateLives()
    {
        for(int i = 0; i < livesObjects.Length; i++)
        {
            if(i <= lives)
            {
                livesObjects[i].SetActive(true);
            }
            else
            {
                livesObjects[i ].SetActive(false);
            }
        }

        if(lives < 0)
        {
            gameOverScreen.SetActive(true);
            //Pass in info for homework - 
            Destroy(GetComponent<Whale_Movement>());
        }
    }
}

