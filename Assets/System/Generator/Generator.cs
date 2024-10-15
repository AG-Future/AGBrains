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
            if (dependingStage)
            {
                spawnCount = FindObjectOfType<StageManager>().currentStageInfo.totalPoint;
            }
            for (; startValue <= spawnCount; startValue++)
            { 
                //var orthographicSize = spawnCamera.orthographicSize; 
                _xPos = UnityEngine.Random.Range((int)minSpawnRange.x,(int)maxSpawnRange.x);
                _yPos = UnityEngine.Random.Range((int)minSpawnRange.y,(int)maxSpawnRange.y);
                GeneratePos = new Vector2(_xPos, _yPos);
                Check(preFabType);
               
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
