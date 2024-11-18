using System.Collections;
using Player;
using UnityEngine;

namespace CoinsAndAugments
{
    public class SpeedUp : MonoBehaviour
    {
        //public static Action SUConsume;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            IncreaseSpeed();
            AudioManager.AudioManager.Instance.Play("Sounds/SpeedUp");
            Destroy(gameObject);
        }
        private IEnumerator SpeedUpFlow()
        {
            Debug.Log("speed");
            PlayerMove.moveSpeed = 400f;
            yield return new WaitForSeconds(0.7f); 
            PlayerMove.moveSpeed = 250f; 
            yield return null;
        }
        private void IncreaseSpeed()
        {
            StartCoroutine(SpeedUpFlow());
        }
    }
}
