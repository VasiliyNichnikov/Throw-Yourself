using System.Collections;
using UnityEngine;

namespace Particulars
{
    public class ActivatorParticle : MonoBehaviour
    {
        private ParticleSystem _particle;

        private void Awake()
        {
            _particle = GetComponent<ParticleSystem>();
            if (_particle == null) return;
            Play();
        }

        private void Play()
        {
            StartCoroutine(CheckingEndOfAnimationOfParticular());
        }

        private IEnumerator CheckingEndOfAnimationOfParticular()
        {
            _particle.Play();
            while (_particle.isPlaying)
            {
                yield return null;
            }

            Destroy(this.gameObject);
        }
    }
}