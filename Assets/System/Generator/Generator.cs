using System.StageSystem.StageScript;
using UnityEngine;
using UnityEngine.Serialization;

namespace System.Generator
{
    public class Generator : MonoBehaviour
    {
        protected Vector2 GeneratePos;
        [Header("초기값 설정")]
        [SerializeField] protected int startValue;
        [FormerlySerializedAs("spwanCount")] [SerializeField] protected int spawnCount;
        [Header("해당 스테이지 값만큼 생성")] [SerializeField]
        protected bool dependingStage;
        [Header("생성 범위 설정")]
        [FormerlySerializedAs("maxSpwanRange")] [SerializeField] protected Vector2 maxSpawnRange;
        [FormerlySerializedAs("minSpwanRange")] [SerializeField] protected Vector2 minSpawnRange;
        [Header("생성 각도 설정")]
        [FormerlySerializedAs("spwanAngle")] [SerializeField] protected Vector3 spawnAngle;
        private int _xPos;
        private int _yPos;
        public GameObject preFab;

        protected void Spawn(GameObject preFabType)
        {
            var timeout = 0f;
            if (dependingStage)
            {
                spawnCount = FindObjectOfType<StageManager>().currentStageInfo.totalPoint;
            }
            for (; startValue <= spawnCount; startValue++)
            {
                timeout += Time.deltaTime;
                //var orthographicSize = spawnCamera.orthographicSize; 
                _xPos = UnityEngine.Random.Range((int)minSpawnRange.x,(int)maxSpawnRange.x);
                _yPos = UnityEngine.Random.Range((int)minSpawnRange.y,(int)maxSpawnRange.y);
                GeneratePos = new Vector2(_xPos, _yPos);
//                Debug.Log(timeout);
                Check(preFabType);
                if (!(timeout > 10f)) continue;
                Debug.LogError("로딩시간이 오래걸립니다.. 다시 실행해보거나 오브젝트 수를 줄여보세요.");
                break;
            }


        }

        private void Check(GameObject preFabType)
        {
            if (!GenerateList.GeneratesList.Add(GeneratePos)) startValue--;
            else
            {
//              Debug.Log(preFabType);
//              Debug.Log(GenerateList.generateList);
                Instantiate(preFabType, GeneratePos, Quaternion.Euler(spawnAngle));
            }
        }
    }
}
