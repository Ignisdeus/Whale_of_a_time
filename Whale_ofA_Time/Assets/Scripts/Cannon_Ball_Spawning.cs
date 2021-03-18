using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Ball_Spawning : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(CannonBallSpawning()); // call coroutine
    }

    public GameObject cannonBall;
    public float force;
    [Range(2f, 15f)]
    public float spawingMax; 
    IEnumerator CannonBallSpawning()
    {
        GameObject ball = Instantiate(cannonBall, transform.position, Quaternion.identity); // create the cannon ball 
        ball.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force); // add force to the cannon ball
        yield return new WaitForSeconds(Random.Range(1f, spawingMax)); // wait for range of time 
        StartCoroutine(CannonBallSpawning()); // call coroutine
    }

}
