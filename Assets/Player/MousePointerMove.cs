using System.StageSystem.StageScript;
using UnityEngine;

namespace Player
{
    public class MousePointerMove : MonoBehaviour
    {
        private string _interactingWith;
        private Camera _mainCamera;
        private StageManager _stageManager;
        private RaycastHit2D _hit;
        private void Start()
        {
            _stageManager = FindObjectOfType<StageManager>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _hit = Physics2D.Raycast(transform.position, Vector2.zero);
                switch (_hit.collider.tag)
                {
                    case "newgame":
                        _stageManager.StageSet();
                        break;
                    case "loadgame":
                        _stageManager.StageLoad();
                        break;
                    case "tomain":
                        _stageManager.ReStage();
                        break;
                    case "quitgame":
                        Application.Quit();
                        break;
                    
                }
            }

        }

        /*private void OnTriggerEnter2D(Collider2D other)
        {
            _interactingWith = other.tag;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactingWith = "";
        }*/
    }
}
