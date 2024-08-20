using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 500;
        
        private int _direction = 8;
        public static string Dir;
        
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            AudioManager.AudioManager.Instance.SetAsBGM("Sounds/sol1");
        }
        
        private void Update()
        {
            new Networking.Get<DirectionResponses>("/get-direction").OnResponse(dr => _direction = dr.direction).OnError(_ => _direction = 8).Build();
            Move();
        }

        private void Move()
        {
            switch (_direction)
            {
                case 0:
                    // UP
                    Dir = "up";
                    _rb.velocity = new Vector2(0f, moveSpeed * Time.deltaTime);
                    break;
                case 1:
                    // UP-RIGHT
                    break;
                case 2:
                    // RIGHT
                    Dir = "right";
                    _rb.velocity = new Vector2(moveSpeed * Time.deltaTime, 0f);
                    break;
                case 3:
                    // DOWN-RIGHT
                    break;
                case 4:
                    Dir = "down";
                    _rb.velocity = new Vector2(0f, -moveSpeed * Time.deltaTime);
                    // DOWN
                    break;
                case 5:
                    // DOWN-LEFT
                    break;
                case 6:
                    // LEFT
                    Dir = "left";
                    _rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0f);
                    break;
                case 7:
                    // UP_LEFT
                    break;
                case 8:
                    // STAY
                    Dir = "stay";
                    _rb.velocity = new Vector2(0f, 0f);
                    break;
            }
        }
    }
}
