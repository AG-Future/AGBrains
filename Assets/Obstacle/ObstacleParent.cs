using UnityEngine;
using UnityEngine.Serialization;

namespace Obstacle
{
    public class ObstacleParent : MonoBehaviour
    {
        [Header("닿을 때 데미지를 주는가")]
        [SerializeField] protected bool isTrigger;
        [Header("콜라이더 설정")] 
        [SerializeField] protected Collider2D localCollider2D;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("YouDie");
            }
        }

        protected void SetCollider2D()
        {
            localCollider2D.isTrigger = isTrigger;
        }
    }
}
