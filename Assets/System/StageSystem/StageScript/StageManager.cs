using UnityEngine;

namespace System.StageSystem.StageScript
{
    public class StageManager : MonoBehaviour
    {
        [Header("각 스테이지 정보")]
        public StageInfo[] stageInfos;
        [Header("현재 스텡이지 점수와 움직임 수")]
        public int currentPoint;
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        private void Update()
        {
        
        }
    }
}
