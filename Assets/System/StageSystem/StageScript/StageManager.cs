using UnityEngine;
using UnityEngine.SceneManagement;

namespace System.StageSystem.StageScript
{
    public class StageManager : MonoBehaviour
    {
        [Header("각 스테이지 정보")]
        public StageInfo[] stageInfos;
        [Header("현재 스테이지 점수")]
        public int currentPoint;
        public int currentStageTag;
        public StageInfo currentStageInfo;
        
        private void Start()
        {
            currentStageInfo = stageInfos[0];
            DontDestroyOnLoad(gameObject);
        }

        public void StageLoad()
        {
            currentStageTag = PlayerPrefs.GetInt("stage");
            currentStageInfo = stageInfos[currentStageTag];
            SceneManager.LoadScene(currentStageInfo.stageTag);
            currentPoint = currentStageInfo.totalPoint;
        }

        public void StageSet()
        {
            PlayerPrefs.SetInt("stage", 1);
            StageLoad();
        }

        public void NextStage()
        {
            PlayerPrefs.SetInt("stage", ++currentStageTag);
            StageLoad();
        }
    }
}
