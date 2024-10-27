using System;
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
            while (PlayerMove.moveSpeed < 1000)
            {
                PlayerMove.moveSpeed += 300f;
                yield return null;
            }
            yield return new WaitForSeconds(2f);
            while (PlayerMove.moveSpeed > 500)
            {
                PlayerMove.moveSpeed -= 300f;
                yield return null;
            }
        }
        private void IncreaseSpeed()
        {
            StartCoroutine(SpeedUpFlow());
        }
    }
}
