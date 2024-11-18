using UnityEngine;

namespace System.StageSystem.StageScript
{
    public class DieSceneManager : MonoBehaviour
    {
        private StageManager _sm;
        private void Awake()
        {
            _sm = GameObject.FindWithTag("stageManager").gameObject.GetComponent<StageManager>();
        }

        public void ToMain()
        {
            _sm.ToMain();
        }

        public void Continue()
        {
            _sm.StageLoad();
        }
    }
}
