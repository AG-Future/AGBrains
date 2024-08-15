using Player;
using TMPro;
using UnityEngine;

namespace Panels
{
    public class Panel : MonoBehaviour
    {
        private TextMeshPro _text;
        private Animator _panelAni;
        
        private string _currentDir;

        private static readonly int Change = Animator.StringToHash("change");

        private void Start()
        {
            _text = GetComponentInChildren<TextMeshPro>();
            _panelAni = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!PlayerMove.Dir.Equals(_currentDir)) SetCon(PlayerMove.Dir);
        }

        private void SetCon(string moveDir)
        {
            _currentDir = moveDir;
            _text.text = moveDir;
            _panelAni.SetTrigger(Change);
        }
    }
}
