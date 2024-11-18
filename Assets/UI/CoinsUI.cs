using System;
using System.StageSystem.StageScript;
using CoinsAndAugments;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinsUI : MonoBehaviour
    {
        public static int Count;
        private TextMeshProUGUI _coinText;
        public static Action CanEnterGoal;

        private void Start()
        {
            Coins.CoinConsume += AddPoint;

            _coinText = GetComponent<TextMeshProUGUI>();
            _coinText.text = "Coin X" + FindObjectOfType<StageManager>().currentPoint;
        }

        public void Minus()
        {
            Coins.CoinConsume -= AddPoint;
        }

        public void AddPoint()
        {
            var stageManager = FindObjectOfType<StageManager>();
            _coinText.text = "Coin X" + --stageManager.currentPoint;
            if (stageManager.currentPoint > 0) return;
            CanEnterGoal?.Invoke();
            _coinText.text = "Goto Object";
            Coins.CoinConsume -= AddPoint;
            Count--;
        }
    }
}
