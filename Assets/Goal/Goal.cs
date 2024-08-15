using UnityEngine;

namespace Goal
{
    public class Goal : MonoBehaviour
    {
        private GameObject _player;
        private Vector2 _playerPos;
        void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }
        
        void Update()
        {
            _playerPos = _player.transform.position;
            if (Vector2.Distance(gameObject.transform.position, _playerPos) < 0.1f)
            {
                Debug.Log("!");
            }
        }
    }
}
