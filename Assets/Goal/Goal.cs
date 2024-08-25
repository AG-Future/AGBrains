using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Goal
{
    public class Goal : MonoBehaviour
    {
        private Transform _player;
        private SpriteRenderer render;

        private void Start()
        {
            render = GetComponent<SpriteRenderer>();
            _player = GameObject.FindWithTag("Player").transform;
        }

        private void Update()
        {
            

            if (Score.score == 1)
            {
                Clear();
            }
        }
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if (!other.CompareTag("Player"))
        //     {
        //         Next();
        //     }
        //
        // }
        //쇼발 어떻게 하는지 모르겠어.

        public void Clear()
        {
            render.color = new Color(0, 255, 0, 1);
            if (Vector2.Distance(transform.position, _player.position) < 0.1f) Debug.Log("Reach the Goal!");
            
        }

        private void Next()
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
