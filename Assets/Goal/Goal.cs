using UnityEngine;

namespace Goal
{
    public class Goal : MonoBehaviour
    {
        private GameObject _player;
        private Vector2 _playerPos;
        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
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
