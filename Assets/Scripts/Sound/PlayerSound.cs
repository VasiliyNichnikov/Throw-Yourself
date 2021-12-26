using System.Collections;
using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        private IEnumerator _runningPlayback;

        public void TurnOn(AudioClip clip, float volume)
        {
            volume = Mathf.Clamp01(volume);
            _source.clip = clip;
            _source.volume = volume;
            _source.Play();
            _runningPlayback = AudioPlayback();
            StartCoroutine(_runningPlayback);
        }

        private void OnApplicationQuit()
        {
            if(_runningPlayback != null)
                StopCoroutine(_runningPlayback);
        }

        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }


        private IEnumerator AudioPlayback()
        {
            while (_source.isPlaying)
            {
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}