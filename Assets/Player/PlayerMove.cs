using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        private int _direction = 8;
        [SerializeField] private int reqDirection = 8;
        private void Update()
        {
            new Networking.Post<Void>("/set-direction", null).AddParam("direction", reqDirection + "").Build();
            new Networking.Get<DirectionResponses>("/get-direction").OnResponse(dr => _direction = dr.direction).OnError((_) => _direction = 8).Build();
            Move();
        }

        private void Move()
        {
            Debug.Log(_direction);
            switch (_direction)
            {
                case 0:
                    // UP
                    break;
                case 1:
                    // UP-RIGHT
                    break;
                case 2:
                    // RIGHT
                    break;
                case 3:
                    // DOWN-RIGHT
                    break;
                case 4:
                    // DOWN
                    break;
                case 5:
                    // DOWN-LEFT
                    break;
                case 6:
                    // LEFT
                    break;
                case 7:
                    // UP_LEFT
                    break;
                case 8:
                    // STAY
                    break;
            }
        }
    }
}
