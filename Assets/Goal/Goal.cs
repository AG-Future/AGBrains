using System.Collections;
using System.StageSystem.StageScript;
using Player;
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
        private StageManager _stageManager;
        private BoxCollider2D _bCol2D;
        public static int count = 0;
        
        private void Start()
        {

            _bCol2D = GetComponent<BoxCollider2D>();
            _bCol2D.enabled = true;


            _stageManager = FindObjectOfType<StageManager>();

            CoinsUI.CanEnterGoal += ChangeColor;  


            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = Color.gray;
        }

        private void Update()
        {
            //if (Vector2.Distance(transform.position, _player.position) < 0.1f) Debug.Log("Reach the Goal!");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_stageManager.currentPoint > 0 || !other.CompareTag("Player")) return;
            PlayerMove.canMove = false;
            CoinsUI.CanEnterGoal -= ChangeColor;
            count--;
            _bCol2D.enabled = false;
            _stageManager.NextStage();
        }

        public void Minus()
        {
            CoinsUI.CanEnterGoal -= ChangeColor;
        }
        public void ChangeColor()
        {
            StartCoroutine(ColorChangeFlow());
        }

        private IEnumerator ColorChangeFlow()
        {
            for (float i = 0; i <= changeTime; i += Time.deltaTime)
            {
                _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.green, 2f*Time.deltaTime);
                yield return null;
            }
        }
    }
}
