using Player;
using UnityEngine;

namespace Goal
{
    public class Goal : MonoBehaviour
    {
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, _player.position) < 0.1f) Debug.Log("Reach the Goal!");
        }
    }
}
