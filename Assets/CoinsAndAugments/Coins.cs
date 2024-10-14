using System;
using UnityEngine;

namespace CoinsAndAugments
{
    public class Coins : MonoBehaviour
    {
        public static Action CoinConsume;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            CoinConsume?.Invoke();
            AudioManager.AudioManager.Instance.Play("Sounds/Insert Coin");
            Destroy(gameObject);
        }
    }
}
