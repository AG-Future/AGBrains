using UnityEngine;

namespace AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        public static string SoundKind;
        public static bool Play;

        private AudioSource _audioSource;
        private void Start()
        {
            SoundKind = "None";
            Play = false;
            _audioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            var coin = Resources.Load<AudioClip>("Sounds/Insert Coin");
            if (!Play) return;
            switch(SoundKind)
            {
                case "Coin":
                    _audioSource.PlayOneShot(coin);
                    SoundKind = "None";
                    Play = false;
                    break;
            }
        }
    }
}
