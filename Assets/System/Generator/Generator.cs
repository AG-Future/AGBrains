using UnityEngine;

namespace System
{
    public class Generator : MonoBehaviour
    {
        protected Vector2 generatePos;
        [Header("초기값 설정")]
        [SerializeField]protected int startValue;
        [SerializeField]protected int spwanCount;
        [Header("생성 범위 설정")]
        [SerializeField] protected Vector2 maxSpwanRange;
        [SerializeField] protected Vector2 minSpwanRange;
        [Header("생성 각도 설정")]
        [SerializeField] protected Vector3 spwanAngle;
        protected int xPos;
        protected int yPos;
        public GameObject preFab;
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void Spawn(GameObject preFabType)
        {
            for (; startValue <= spwanCount; startValue++)
            { 
                //var orthographicSize = spwanCamera.orthographicSize; 
                xPos = UnityEngine.Random.Range((int)minSpwanRange.x,(int)maxSpwanRange.x);
                yPos = UnityEngine.Random.Range((int)minSpwanRange.y,(int)maxSpwanRange.y);
                generatePos = new Vector2(xPos, yPos);
                Check(preFabType);
               
            }
        }
        public void Check(GameObject preFabType)
        {
                if (GenerateList.generateList.Contains(generatePos))
                {
                    startValue--;
                }
                else
                {
                    Debug.Log(preFabType);
                    GenerateList.generateList.Add(generatePos);
                    Debug.Log(GenerateList.generateList);
                    Instantiate(preFabType, generatePos, Quaternion.Euler(spwanAngle));
                }
                
        }
    }
}
