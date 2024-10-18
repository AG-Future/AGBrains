using System;
using System.Collections;
using System.StageSystem.StageScript;
using CoinsAndAugments;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinsUI : MonoBehaviour
    {
        private TextMeshProUGUI _coinText;
        public static Action CanEnterGoal;
        private void Start()
        {
            Coins.CoinConsume += AddPoint;
            _coinText = GetComponent<TextMeshProUGUI>();
            _coinText.text = "Coin X"+FindObjectOfType<StageManager>().currentPoint;
            
        }

        public void Minus()
        {
            Coins.CoinConsume -= AddPoint;
        }

        public void AddPoint()
        {
            _coinText.text = "Coin X"+(FindObjectOfType<StageManager>().currentPoint-1);
            FindObjectOfType<StageManager>().currentPoint--;
            if (FindObjectOfType<StageManager>().currentPoint > 0) return;
            CanEnterGoal?.Invoke();
            _coinText.text = "Goto Object";
            Coins.CoinConsume -= AddPoint;
        }


    }
}
