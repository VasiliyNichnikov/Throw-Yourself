using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class EngineOfSoul : MonoBehaviour
    {
        private Transform _thisTransform;

        public void Move(Vector3 positionEnd, float duration, bool snapping = false)
        {
            _thisTransform.DOMove(positionEnd, duration, snapping).OnComplete(() => Destroy(this.gameObject));
            // _thisTransform.DOScale()
        }

        public void Init()
        {
            _thisTransform = transform;
            DOTween.Init();
        }
    }
}