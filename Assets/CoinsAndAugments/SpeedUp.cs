using System;
using Unity.VisualScripting;
using UnityEngine;

namespace CoinsAndAugments
{
    public class SpeedUp : MonoBehaviour
    {
        public static Action SUConsume;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            SUConsume?.Invoke();
            AudioManager.AudioManager.Instance.Play("Sounds/SpeedUp");
            Destroy(gameObject);
        }
    }
}
