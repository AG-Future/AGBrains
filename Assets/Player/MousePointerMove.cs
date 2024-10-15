using System.StageSystem.StageScript;
using UnityEngine;

namespace Player
{
    public class MousePointerMove : MonoBehaviour
    {
        private string _interactingWith;
        private Camera _mainCamera;
        private StageManager _stageManager;

        private void Start()
        {
            _stageManager = FindObjectOfType<StageManager>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            transform.position = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (!Input.GetMouseButtonDown(0)) return;
            switch (_interactingWith)
            {
                case "newgame":
                    _stageManager.StageSet();
                    break;
                case "loadgame":
                    _stageManager.StageLoad();
                    break;
                case "quitgame":
                    Application.Quit();
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _interactingWith = other.tag;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactingWith = "";
        }
    }
}
