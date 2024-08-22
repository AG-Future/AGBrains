using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")) Debug.Log("Player Detected"); //여기 변경해서 게임오버 화면이든지 처음으로 돌아가게 만들면 됨
    }
}