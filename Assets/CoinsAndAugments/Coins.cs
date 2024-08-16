using System.Collections;
using UnityEngine;

namespace CoinsAndAugments
{
    public class Coins : MonoBehaviour
    {
        private AudioSource _coinInsert;
        private void Start()
        {
            _coinInsert = gameObject.GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            _coinInsert.Play();
            Destroy(gameObject);

        }
    }
}
