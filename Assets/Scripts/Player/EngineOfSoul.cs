using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class EngineOfSoul : MonoBehaviour
    {
        public delegate void CompletionOfMovement();

        private Transform _thisTransform;

        public void Move(Vector3 positionEnd, float duration, bool snapping = false)
        {
            _thisTransform.DOMove(positionEnd, duration, snapping).OnComplete(() => Destroy(this.gameObject));
        }

        public void Move(Vector3 positionEnd, float duration, CompletionOfMovement actionAfterMovement,
            bool snapping = false)
        {
            _thisTransform.DOMove(positionEnd, duration, snapping).OnComplete(() =>
            {
                actionAfterMovement();
                Destroy(this.gameObject);
            });
        }


        public void Init()
        {
            _thisTransform = transform;
            DOTween.Init();
        }
    }
}