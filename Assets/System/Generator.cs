using Unity.VisualScripting;
using UnityEngine;

namespace System
{
    public class Generator : MonoBehaviour
    {
        protected Vector2 generatePos;
        protected int spwanCount;
        protected int xPos;
        protected int yPos;
        protected bool interactingWithSomebody;
        protected int startValue;
        [SerializeField] protected GameObject gameObject;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Spawn(GameObject preFabType)
        {
            for (startValue = 1; startValue <= spwanCount; startValue++)
            {
               xPos = UnityEngine.Random.Range(0, Screen.width);
               yPos = UnityEngine.Random.Range(0, Screen.height);
               Check();
               
            }
        }
        protected void Check()
        {
            if (GenerateList.generateList.Contains(new Vector2(xPos,yPos)))
            {
                startValue--;
            }
            else
            {
                Instantiate(gameObject, new Vector2(xPos, yPos), Quaternion.identity);
            }
            
            
        }
    }
}
