using System.Collections.Generic;
using UnityEngine;

namespace AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        public static string SoundKind;

        private AudioSource _audioSource;

        private static readonly Dictionary<string, AudioClip> Clips = new();

        public static AudioManager Instance;
        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void Play(string path)
        {
            _audioSource.PlayOneShot(GetClip(path));
        }

        public void SetAsBGM(string path)
        {
            _audioSource.clip = GetClip((path));
            _audioSource.loop = true;
            _audioSource.Play();
        }

        private static AudioClip GetClip(string path)
        {
            if (Clips.TryGetValue(path, out var clip)) return clip;
            clip = Resources.Load<AudioClip>(path);
            if (!clip) return null;
            return Clips[path] = clip;
        }
    }
}
