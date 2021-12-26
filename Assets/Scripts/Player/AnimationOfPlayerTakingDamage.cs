using System.Collections;
using UnityEngine;

namespace Player
{
    public class AnimationOfPlayerTakingDamage : MonoBehaviour
    {
        private static readonly int TakingDamage = Shader.PropertyToID("takingDamage");
        [SerializeField, Range(0, 50)] private float _speedWhenTakingImage;
        [SerializeField, Range(0, 50)] private float _speedAfterTakingDamage;
        private Material _material;
        private IEnumerator _runningAnimation;
        private float _valueNow;

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
        }

        public void LauncherAnimationDamage()
        {
            if (_runningAnimation != null) return;
            _runningAnimation = AnimationTakingDamage();
            StartCoroutine(_runningAnimation);
        }


        private IEnumerator AnimationTakingDamage()
        {
            _valueNow = 0;
            yield return AnimationToValueEnd(1, _speedWhenTakingImage);
            _valueNow = 1;
            yield return AnimationToValueEnd(0, _speedAfterTakingDamage);
            _runningAnimation = null;
        }

        private IEnumerator AnimationToValueEnd(float valueEnd, float speed)
        {
            float difference = Mathf.Abs(valueEnd - _valueNow);
            while (difference >= 0.1f)
            {
                _valueNow = Mathf.Lerp(_valueNow, valueEnd, Time.deltaTime * speed);
                print(_valueNow);
                _material.SetFloat(TakingDamage, _valueNow);
                yield return null;
                difference = Mathf.Abs(valueEnd - _valueNow);
            }
        }
    }
}