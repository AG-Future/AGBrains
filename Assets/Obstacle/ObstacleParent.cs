using System.StageSystem.StageScript;
using Player;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

namespace Obstacle
{
    public class ObstacleParent : MonoBehaviour
    {
        [Header("닿을 때 데미지를 주는가")]
        [SerializeField] protected bool isTrigger;
        [Header("콜라이더 설정")] 
        [SerializeField] protected Collider2D localCollider2D;
        protected CoinsUI _coinsUI;
        protected Goal.Goal _goal;
        protected StageManager _stageManager;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerMove.canMove = false;
                Debug.Log("YouDie");
                _coinsUI.Minus();
                _goal.Minus();
                localCollider2D.enabled = false;
                _stageManager.GameOver();
                
            }
        }

        protected void SetObstacle()
        {
            _stageManager = GameObject.FindWithTag("stageManager").gameObject.GetComponent<StageManager>();
            localCollider2D.enabled = true;
            _coinsUI = GameObject.FindWithTag("coinsui").gameObject.GetComponent<CoinsUI>();
            _goal = GameObject.FindWithTag("goal").gameObject.GetComponent<Goal.Goal>();
            SetCollider2D();
        }
        protected void SetCollider2D()
        {
            localCollider2D.isTrigger = isTrigger;
        }
    }
}
