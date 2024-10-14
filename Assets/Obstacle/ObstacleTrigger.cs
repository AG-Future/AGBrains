using UnityEngine;

namespace Obstacle
{
    [RequireComponent(typeof(Collider2D))]
    public class ObstacleTrigger : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) Debug.Log("Player Detected"); //여기 변경해서 게임오버 화면이든지 처음으로 돌아가게 만들면 됨
        }
    }
}