using System.StageSystem.StageScript;
using CoinsAndAugments;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinsUI : MonoBehaviour
    {
        private TextMeshProUGUI _coinText;
        private void Start()
        {
            Coins.CoinConsume += AddPoint;
            _coinText = GetComponent<TextMeshProUGUI>();
            _coinText.text = "Coin X"+FindObjectOfType<StageManager>().currentPoint;
            
        }

        private void AddPoint()
        {
            _coinText.text = "Coin X"+(FindObjectOfType<StageManager>().currentPoint-1);
            FindObjectOfType<StageManager>().currentPoint--;
            if (FindObjectOfType<StageManager>().currentPoint <= 0)
            {
                _coinText.text = "Goto Object";
                Coins.CoinConsume -= AddPoint;
            }
        }
    }
}
