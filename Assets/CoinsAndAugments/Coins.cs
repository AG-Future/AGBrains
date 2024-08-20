using UnityEngine;

namespace CoinsAndAugments
{
    public class Coins : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            AudioManager.AudioManager.Instance.Play("Sounds/Insert Coin");
            Destroy(gameObject);

        }
    }
}
