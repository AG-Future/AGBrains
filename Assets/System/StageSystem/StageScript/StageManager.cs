using System.Collections;
using System.Collections.Generic;
using System.Generator;
using System.Net.Mime;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        [Header("Fade 정보")]
        public Color fade;
        public RawImage fadeImg;
        [SerializeField] private float fadeSpeed;
        private GameObject[] _doublecheck;
        
        private void Start()
        {
            _doublecheck = GameObject.FindGameObjectsWithTag("stageManager");
            if (_doublecheck.Length > 1)
            {
                Destroy(gameObject);
            }
            currentStageInfo = stageInfos[0];
            DontDestroyOnLoad(gameObject);
            fadeImg.color = fade = new Color(0, 0, 0, 0);
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
            GenerateList.GeneratesList.Clear();
            currentStageTag = PlayerPrefs.GetInt("stage");
            currentStageInfo = stageInfos[currentStageTag];
            SceneManager.LoadSceneAsync(currentStageInfo.stageTag).completed += a => StartCoroutine(FadeOutFlow());
            currentPoint = currentStageInfo.totalPoint; 
        }

        public void StageSet()
        {
            PlayerPrefs.SetInt("stage", currentStageTag = 1);
            StartCoroutine(FadeInFlow());
        }

        public void ToMain()
        {
            SceneManager.LoadScene(0);
        }

        public void GameOver()
        {
            StartCoroutine(GameOverFlow());
        }

        public void NextStage()
        {
            PlayerPrefs.SetInt("stage", ++currentStageTag);
            StartCoroutine(FadeInFlow());
        }

        private IEnumerator FadeInFlow()
        {
            var alpha = 0f;
            fadeImg.color = fade = new Color(0, 0, 0, alpha);
            while (alpha < 1)
            {
                alpha+=Time.deltaTime*fadeSpeed;
                fadeImg.color = fade = new Color(0, 0, 0, alpha);
                yield return null;
            }

            yield return null;
            StageLoad();

        }
        private IEnumerator GameOverFlow()
        {
            var alpha = 0f;
            fadeImg.color = fade = new Color(0, 0, 0, alpha);
            while (alpha < 1)
            {
                alpha+=Time.deltaTime*fadeSpeed;
                fadeImg.color = fade = new Color(0, 0, 0, alpha);
                yield return null;
            }

            yield return null;
            SceneManager.LoadScene(6);

        }

        private IEnumerator FadeOutFlow()
        {
            var alpha = 1f;
            fadeImg.color = fade = new Color(0, 0, 0, alpha);
            while (alpha > 0)
            {
                alpha-=Time.deltaTime*fadeSpeed;
                fadeImg.color = fade = new Color(0, 0, 0, alpha);
                yield return null;
            }
        }
    }
}
