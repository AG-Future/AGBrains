using System.Collections;
using System.StageSystem.StageScript;
using UI;
using UnityEngine;

namespace Goal
{
    public class Goal : MonoBehaviour
    {
        [Header("색 변경에 걸리는 시간")] [SerializeField]
        private float changeTime;
        //private Transform _player;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            CoinsUI.CanEnterGoal += ChageColor;
            //_player = GameObject.FindWithTag("Player").transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = Color.red;
        }

        private void Update()
        {
            //if (Vector2.Distance(transform.position, _player.position) < 0.1f) Debug.Log("Reach the Goal!");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (FindObjectOfType<StageManager>().currentPoint <= 0&&other.CompareTag("Player"))
            {
                CoinsUI.CanEnterGoal -= ChageColor;
                FindObjectOfType<StageManager>().NextStage();
            }
        }

        private void ChageColor()
        {
            StartCoroutine(ColorChageFlow());
        }

        private IEnumerator ColorChageFlow()
        {
            for (float i = 0; i <= changeTime; i += Time.deltaTime)
            {
                _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.green, 2f*Time.deltaTime);
                yield return null;
            }

        }
    }
}
