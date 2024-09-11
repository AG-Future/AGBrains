using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleObject : MonoBehaviour
    {
        void Start()
        {
        
        }
        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("YouDie");
            }
        }
    }
}
