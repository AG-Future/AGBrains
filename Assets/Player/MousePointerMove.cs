using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class MousePointerMove : MonoBehaviour
    {
        
        private Vector3 _positon;
        private string _interactingWith;
        private void Start()
        {
            
        }

        private void Update()
        {
            _positon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(_positon.x, _positon.y);
            if (Input.GetMouseButtonDown(0))
            {
                switch (_interactingWith)
                {
                    case "newgame":
                        SceneManager.LoadScene("Stage1");
                        break;
                    case "loadgame":
                        Debug.Log(_interactingWith);
                        break;
                    case "quitgame":
                        Application.Quit();
                        break;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(1);
            if (other.CompareTag("newgame"))
            {
                _interactingWith = "newgame";
            }
            else if (other.CompareTag("loadgame"))
            {
                _interactingWith = "loadgame";
            }
            else if (other.CompareTag("quitgame"))
            {
                _interactingWith = "quitgame";
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactingWith = "";
        }
    }
}
