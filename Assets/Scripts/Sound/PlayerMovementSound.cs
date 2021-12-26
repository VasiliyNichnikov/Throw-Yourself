using System.Collections;
using UnityEngine;

namespace Sound
{
    
    [RequireComponent(typeof(AudioSource))]
    public class PlayerMovementSound : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _clips;
        private AudioSource _source;
        private IEnumerator _runningAudio;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
        }

        public void LauncherPlayback()
        {
            if (_runningAudio != null) return;
            _runningAudio = AudioPlayback();
            StartCoroutine(_runningAudio);
        }

        private IEnumerator AudioPlayback()
        {
            int index = Random.Range(0, _clips.Length - 1);
            _source.clip = _clips[index];
            _source.Play();
            while (_source.isPlaying)
            {
                yield return null;
            }

            _runningAudio = null;
        }
    }
}