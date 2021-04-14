using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Timer : MonoBehaviour
{
    [Range(0.01f, 10f)]
    public float timer = 5f; 
    void Start()
    {
        Destroy(this.gameObject, timer);
    }

}
