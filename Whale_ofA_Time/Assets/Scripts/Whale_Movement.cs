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
    private AudioSource audioSourse;
    public AudioClip jumpAudio, hitAudio; 
    void Start()
    {
        audioSourse = gameObject.AddComponent<AudioSource>();// will add a AudioSource component to the game object
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
            audioSourse.PlayOneShot(jumpAudio, 0.7f);
            grounded = false; 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }
    }

    public GameObject bubbles; 
    void OnCollisionEnter2D(Collision2D other){
        // if I collide with the ball display debug. 
        if(other.gameObject.tag =="Ball"){
            audioSourse.PlayOneShot(hitAudio, 0.7f);
            Instantiate(bubbles, transform.position, Quaternion.identity);
            StartCoroutine(WhaleFlash());
            Destroy(other.gameObject);
            lives--; // reduce lives by one
            UpdateLives();
            transform.position = startingPos; // reset my posision  
        }
    }
    [Range(0.01f, 1f)]
    public float waitTimer = 0.2f;
    public GameObject whaleImage;
    public int iterations = 3; 
    IEnumerator WhaleFlash()
    {
        for(int i = 0; i < iterations; i++) {

            if(i % 2 == 0)
            {
                whaleImage.SetActive(true);
            }
            else
            {
                whaleImage.SetActive(false);
            }
            yield return new WaitForSeconds(waitTimer);
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
    public int score = 0;
    public Text scoreText; 
    void AddScore()
    {
        score += 100;// adds 100 to the score
        scoreText.text = score.ToString(); // display score to screen 
    }
    public GameObject gameOverScreen;
    public Text endScore;
    public GameObject GM; 
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
            endScore.text = score.ToString();
            GM.GetComponent<HighScore>().currentScore = score;
            GM.GetComponent<HighScore>().HighScoreCheck(); 
            Destroy(GetComponent<Whale_Movement>());
        }
    }
}

