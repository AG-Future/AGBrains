using UnityEngine;

namespace Obstacle.Suriken
{
    public class Suriken : ObstacleParent
    {
        private void Start()
        {
            SetObstacle();
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0f,0f,0.8f));
        }
    }
}

