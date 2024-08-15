
using Player;
using TMPro;
using UnityEngine;
namespace Panels
{
    public class Panel : MonoBehaviour
    {
        private TextMeshPro _text;
        private string _moveDir;
        private string _currentMove;
        private Animator _panelAni;
        private bool _isChange;
        private static readonly int Change = Animator.StringToHash("change");

        void Start()
        {
            _isChange = false;
            _text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
            _panelAni = GetComponent<Animator>();
        }
    
        void Update()
        {
            
            _moveDir = PlayerMove._dir;
            switch (_moveDir)
            {
                case "up":
                    SetCon();
                    break;
                case "down":
                    SetCon();
                    break;
                case "left":
                    SetCon();
                    break;
                case "right":
                    SetCon();
                    break;
                case "stay":
                    SetCon();
                    break;
            }

            if (!_moveDir.Equals(_currentMove)) _isChange = false;
            _currentMove = _moveDir;
        }

        private void SetCon()
        {
            if (!_isChange)
            {
                _isChange = true;
                _panelAni.SetTrigger(Change);
            }
            _text.text = _moveDir;
        }
        
    }
}
