using System.Collections;
using UnityEngine;

namespace DirectionMovement
{
    public class StretchingAnimation : MonoBehaviour
    {

        [SerializeField] private float _speed;
        [SerializeField] private Transform _partUp;
        [SerializeField] private Transform _partBottom;
        
        private IEnumerator _runningAnimation;
        private CalculatorPartBottomPoint _calculatorPartBottom;

        private void Awake()
        {
            _calculatorPartBottom = _partBottom.GetComponent<CalculatorPartBottomPoint>();
        }

        public void Stretch(Vector3 direction)
        {
            if (_runningAnimation != null)
                StopCoroutine(_runningAnimation);

            float maxScaleZ = GetMaxScaleZ(direction);
            _runningAnimation = Animation(maxScaleZ);
            StartCoroutine(_runningAnimation);
        }

        private float GetMaxScaleZ(Vector3 direction)
        {
            float magnitude = direction.magnitude;
            return Mathf.Clamp01(magnitude);
        }

        private IEnumerator Animation(float maxScale)
        {
            var partBottomScale = _partBottom.localScale;
            float scaleStart = partBottomScale.z;

            float scaleEndZ = maxScale;

            Vector3 scaleEnd = new Vector3(partBottomScale.x, partBottomScale.y, scaleEndZ);
            while (Mathf.Abs(scaleEndZ - scaleStart) > 0.01f)
            {
                _partBottom.localScale = Vector3.Lerp(_partBottom.localScale, scaleEnd, _speed * Time.deltaTime);
                _partUp.position = _calculatorPartBottom.GetTopmostPointZ();

                yield return null;
            }
        }
    }
}