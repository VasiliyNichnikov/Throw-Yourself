using System.Collections;
using UnityEngine;

namespace LifeSlider
{
    public class AnimationChangingLife : MonoBehaviour
    {
        public bool AnimationEnd => _animationEnd;
        
        [SerializeField, Range(1, 10)] private float _speedAnimation;
        private Material _material;
        private bool _animationEnd;
        private IEnumerator _runningAnimation;
        private static readonly int SliderHp = Shader.PropertyToID("sliderHP");

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().material;
        }
        
        public void StartingAnimation(float from, float to)
        {
            if(_runningAnimation != null)
                StopCoroutine(_runningAnimation);
            
            _animationEnd = false;
            _runningAnimation = ChangeSliderValue(from, to);
            StartCoroutine(_runningAnimation);
        }

        private IEnumerator ChangeSliderValue(float from, float to)
        {
            float now = from;
            float difference = Mathf.Abs(to - from);
            while (difference >= 0.1f)
            {
                now = Mathf.Lerp(now, to, _speedAnimation * Time.deltaTime);
                _material.SetFloat(SliderHp, now);
                yield return new WaitForFixedUpdate();
                difference = Mathf.Abs(to - from);
            }

            _animationEnd = true;
        }
    }
}