using System.Collections;
using System.Generator;
using UI;
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
        private float _escStack;
        private CoinsUI _coinsUI;
        private Goal.Goal _goal;

        private void Awake()
        {
            _doublecheck = GameObject.FindGameObjectsWithTag("stageManager");
            if (_doublecheck.Length > 1) Destroy(gameObject);
        }

        private void Start()
        {
            currentStageInfo = stageInfos[0];
            DontDestroyOnLoad(gameObject);
            fadeImg.color = fade = new Color(0, 0, 0, 0);
            fadeImg.gameObject.SetActive(false);
            _escStack = 0;
        }
        //이거는 나중에 오류테스트할때 쓸거
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
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switch (_escStack)
                {
                    case <=0:
                        _escStack = 1f;
                        break;
                    case >1:
                        break;
                    case >=0.5f:
                        if (_coinsUI is not null && _goal is not null)
                        {
                            _coinsUI.Minus();
                            _goal.Minus();
                        }
                        _escStack = 0;
                        SceneManager.LoadScene(0);
                        break;
                }
            }
            _escStack -= Time.deltaTime;
        }

        public void StageLoad()
        {
            GenerateList.GeneratesList.Clear();
            currentStageTag = PlayerPrefs.GetInt("stage");
            currentStageInfo = stageInfos[currentStageTag];
            SceneManager.LoadSceneAsync(currentStageInfo.stageTag)!.completed += a => StartCoroutine(FadeOutFlow());
            currentPoint = currentStageInfo.totalPoint;
        }

        public void StageSet()
        {
            //CoinsUI.count=1;
            //Goal.Goal.co
            PlayerPrefs.SetInt("stage", currentStageTag = 1);
            StartCoroutine(FadeInFlow());
        }

        public void ReStage()
        {
            PlayerPrefs.SetInt("stage", currentStageTag = 0);
            StartCoroutine(FadeInFlow());
        }

        public void ToMain()
        {
            SceneManager.LoadScene(0);
            fadeImg.color = fade = new Color(0, 0, 0, 0);
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
            fadeImg.gameObject.SetActive(true);
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

            if (SceneManager.GetActiveScene().buildIndex != 5)
            {
                _coinsUI = GameObject.FindWithTag("coinsui").gameObject.GetComponent<CoinsUI>();
                _goal = GameObject.FindWithTag("goal").gameObject.GetComponent<Goal.Goal>();
            }

            fadeImg.gameObject.SetActive(false);
        }
    }
}
