using System.StageSystem.StageScript;
using Unity.VisualScripting;
using UnityEngine;

namespace Goal
{
    public class Goal : MonoBehaviour
    {
        private Transform _player;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            //if (Vector2.Distance(transform.position, _player.position) < 0.1f) Debug.Log("Reach the Goal!");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (FindObjectOfType<StageManager>().currentPoint <= 0&&other.CompareTag("Player"))
            {
                FindObjectOfType<StageManager>().NextStage();
            }
        }
    }
}
