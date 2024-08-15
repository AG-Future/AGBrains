using System.Collections;
using Player;
using TMPro;
using UnityEngine;
namespace Panels
{
    public class Panel : MonoBehaviour
    {
        private TextMeshPro _text;
        private string _moveDir;
        private Animator _panelAni;
        void Start()
        {
            _text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
            _panelAni = GetComponent<Animator>();
        }
    
        void Update()
        {
            
            _moveDir = PlayerMove._dir;
            switch (_moveDir)
            {
                case "up":
                    _text.text = _moveDir;
                    StopCoroutine("PanelUpdate");
                    StartCoroutine("PanelUpdate");
                    break;
                case "down":
                    _text.text = _moveDir;
                    break;
                case "left":
                    _text.text = _moveDir;
                    break;
                case "right":
                    _text.text = _moveDir;
                    break;
                case "stay":
                    _text.text = _moveDir;
                    break;
            }
        }

        IEnumerable PanelUpdate()
        {
            _panelAni.SetTrigger("change");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
