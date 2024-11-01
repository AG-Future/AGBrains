using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        public static float moveSpeed = 125;
        public static bool canMove;
        private int _direction = 8;
        private GameObject _modal;
        public static string Dir;
        private Rigidbody2D _rb;
        private bool _isIdling;
        private bool _modalShown;
        private void Start()
        {
            _modalShown = false;
            canMove = true;
            _rb = GetComponent<Rigidbody2D>();
            _modal = GameObject.FindWithTag("mention");
            AudioManager.AudioManager.Instance.SetAsBGM("Sounds/sol1");
            _modal.SetActive(false);
        }
        private void Update()
        {
            new Networking.Get<DirectionResponses>("/get-direction?idlingTime=10").OnResponse(dr =>
            {
                _direction = dr.direction;
                _isIdling = dr.isIdling;
            }).OnError(_ =>
            {
                _direction = 8;
                _isIdling = false;
            }).Build();
            
            if (Input.GetKey(KeyCode.A))
            {
                _direction = 6;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _direction = 2;
            } 
            else if (Input.GetKey(KeyCode.W))
            {
                _direction = 0;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _direction = 4;
                
            }
            Check();
            if (canMove)
            {
                Move();
                
            }
            else
            {
                _rb.velocity = new Vector2(0, 0);
            }
            Debug.Log(_isIdling);
 
        }

        private void Move()
        {
            switch (_direction)
            {
                case 0:
                    Dir = "up";
                    _rb.velocity = new Vector2(0f, moveSpeed * Time.deltaTime);
                    break;
                case 2:
                    Dir = "right";
                    _rb.velocity = new Vector2(moveSpeed * Time.deltaTime, 0f);
                    break;
                case 4:
                    Dir = "down";
                    _rb.velocity = new Vector2(0f, -moveSpeed * Time.deltaTime);
                    break;
                case 6:
                    Dir = "left";
                    _rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0f);
                    break;
                case 8:
                    Dir = "stay";
                    _rb.velocity = new Vector2(0f, 0f);
                    break;
            }
            
        }

        private void Check()
        {

            if (_isIdling && !_modalShown)
            {
                _modal.SetActive(true);
                _modalShown = true;
            }
            else if(!_isIdling&&_modalShown)
            {
                _modal.SetActive(false);
                _modalShown = false;
            }
        }
    }
}
