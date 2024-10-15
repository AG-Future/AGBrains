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
            SpeedUp.SUConsume += IncreaseSpeed;
            _coinText = GetComponent<TextMeshProUGUI>();
            _coinText.text = "Coin X"+FindObjectOfType<StageManager>().currentPoint;
            
        }

        private void AddPoint()
        {
            _coinText.text = "Coin X"+(FindObjectOfType<StageManager>().currentPoint-1);
            FindObjectOfType<StageManager>().currentPoint--;
            if (FindObjectOfType<StageManager>().currentPoint <= 0)
            {
                CanEnterGoal?.Invoke();
                _coinText.text = "Goto Object";
                Coins.CoinConsume -= AddPoint;
            }
        }

        private void IncreaseSpeed()
        {
            StartCoroutine(SpeedUpFlow());
        }

        private IEnumerator SpeedUpFlow()
        {
            Debug.Log("speed");
            while (PlayerMove.moveSpeed < 1000)
            {
                PlayerMove.moveSpeed += 1f;
                yield return null;
            }
            yield return new WaitForSeconds(2f);
            while (PlayerMove.moveSpeed > 500)
            {
                PlayerMove.moveSpeed -= 1f;
                yield return null;
            }
        }
    }
}
