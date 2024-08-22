using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    
    void Start()
    {
        
    }

    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")){ Debug.Log("Player Detected"); }
    }
}
