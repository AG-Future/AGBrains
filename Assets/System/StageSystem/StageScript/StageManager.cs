using UnityEngine;
using UnityEngine.SceneManagement;

namespace System.StageSystem.StageScript
{
    public class StageManager : MonoBehaviour
    {
        [Header("각 스테이지 정보")]
        public StageInfo[] stageInfos;
        [Header("현재 스텡이지 점수")]
        public int currentPoint;
        public int currnetStageTag;
        public StageInfo currentStageInfo;
        private void Start()
        {
            currentStageInfo = stageInfos[0];
            DontDestroyOnLoad(gameObject);
        }
        private void Update()
        {
        
        }

        public void StageLoad()
        {
            currnetStageTag = PlayerPrefs.GetInt("stage");
            currentStageInfo = stageInfos[currnetStageTag];
            SceneManager.LoadScene(currentStageInfo.StageTag);
            currentPoint = currentStageInfo.TotalPoint;
        }

        public void StageSet()
        {
            PlayerPrefs.SetInt("stage",1);
            currnetStageTag = PlayerPrefs.GetInt("stage");
            currentStageInfo = stageInfos[currnetStageTag];
            SceneManager.LoadScene(currentStageInfo.StageTag);
            currentPoint = currentStageInfo.TotalPoint;
        }

        public void NextStage()
        {
            PlayerPrefs.SetInt("stage",currnetStageTag+1);
            StageLoad();
        }
    }
}
