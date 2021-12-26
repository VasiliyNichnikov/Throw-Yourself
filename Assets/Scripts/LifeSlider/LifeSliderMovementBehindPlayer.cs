using System.Collections;
using UnityEngine;

namespace LifeSlider
{
    public class LifeSliderMovementBehindPlayer : MonoBehaviour
    {
        private Transform _target;
        private Transform _thisTransform;


        public void ToFollow(Transform target, float height)
        {
            _thisTransform = transform;
            StartCoroutine(Tracking(target, height));
        }
        
        private IEnumerator Tracking(Transform target, float height)
        {
            while (true)
            {
                Vector3 targetPosition = target.position;
                Vector3 endPosition = new Vector3(targetPosition.x, height, targetPosition.z);
                _thisTransform.position = endPosition;
                yield return null;
            }
        }
    }
}