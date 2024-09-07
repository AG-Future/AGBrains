using UnityEngine;

namespace System
{
    public class Generator : MonoBehaviour
    {
        protected Vector2 generatePos;
        protected int spwanCount;
        protected int xPos;
        protected int yPos;
        protected int startValue;
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
               xPos = UnityEngine.Random.Range(-6,6);
               yPos = UnityEngine.Random.Range(-6,6);
               generatePos = new Vector2(xPos, yPos);
               Debug.Log(preFabType);
               Check(preFabType);
               
            }
        }
        public void Check(GameObject preFabType)
        {
                if (GenerateList.generateList.Contains(generatePos))
                {
                    Debug.Log(preFabType);
                    startValue--;
                }
                else
                {
                    Debug.Log(preFabType);
                    GenerateList.generateList.Add(generatePos);
                    Debug.Log(GenerateList.generateList);
                    Instantiate(preFabType, generatePos, Quaternion.identity);
                }
                
        }
    }
}
