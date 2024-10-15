using System.Generator;
using UnityEditor.SceneManagement;
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

        /*private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene(5);
                GenerateList.GeneratesList.Clear();
            }
            
            if (!int.TryParse(Input.inputString, out var i)) return;
            PlayerPrefs.SetInt("stage", i);
            Debug.Log($"Key Pressed / cst : {currentStageTag}");
            StageLoad();
        }*/

        public void StageLoad()
        {
            Debug.Log(currentStageTag);
            GenerateList.GeneratesList.Clear();
            currentStageTag = PlayerPrefs.GetInt("stage");
            currentStageInfo = stageInfos[currentStageTag];
            SceneManager.LoadScene(currentStageInfo.stageTag);
            currentPoint = currentStageInfo.totalPoint;
        }

        public void StageSet()
        {
            PlayerPrefs.SetInt("stage", 1);
            currentStageTag = 1;
            StageLoad();
        }

        public void NextStage()
        {
            PlayerPrefs.SetInt("stage", ++currentStageTag);
            StageLoad();
        }
    }
}
