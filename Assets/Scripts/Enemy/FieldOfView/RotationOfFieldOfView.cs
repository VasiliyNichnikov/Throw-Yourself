using System.Collections;
using UnityEngine;

namespace Enemy.FieldOfView
{
    public class RotationOfFieldOfView : MonoBehaviour
    {
        [SerializeField] private Transform _neckEnemy;
        [SerializeField] private Transform _stickman;
        [SerializeField, Range(1, 20)] private float _speedAnimation;
        private Transform _thisTransform;
        private IEnumerator _runningAnimation;
        

        private void Awake()
        {
            _thisTransform = transform;
        }

        public void ChangeRotationState(bool returnToStartRotation)
        {
            if (_runningAnimation != null)
                StopCoroutine(_runningAnimation);
            _runningAnimation = returnToStartRotation
                ? RotationToSelectedTransform(_neckEnemy)
                : RotationToSelectedTransform(_stickman);

            StartCoroutine(_runningAnimation);
        }
        
        private IEnumerator RotationToSelectedTransform(Transform selectedTransform)
        {
            while (true)
            {
                Quaternion rotationEnd = Quaternion.Euler(new Vector3(0, selectedTransform.rotation.eulerAngles.y, 0));
                _thisTransform.rotation =
                    Quaternion.Lerp(_thisTransform.rotation, rotationEnd, Time.deltaTime * _speedAnimation);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}