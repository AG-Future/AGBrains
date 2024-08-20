using UnityEngine;

namespace CoinsAndAugments
{
    public class Coins : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            AudioManager.AudioManager.SoundKind = "Coin";
            AudioManager.AudioManager.Play = true;
            Destroy(gameObject);

        }
    }
}
