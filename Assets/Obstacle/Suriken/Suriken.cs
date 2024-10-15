using UnityEngine;

namespace Obstacle.Suriken
{
    public class Suriken : ObstacleParent
    {
        private void Start()
        {
            SetCollider2D();
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0f,0f,0.8f));
        }
    }
}

