using DG.Tweening;
using UnityEngine;

namespace Key
{
    public class MovingKeyToUI : MonoBehaviour
    {
        [SerializeField, Header("Ключ который будет анимироваться")]
        private RectTransform _rectKeyAnimation;

        [SerializeField, Header("Время анимации изменения размера"), Range(0, 10)]
        private float _timeResize;

        [SerializeField, Header("Время анимации движения из точки А в Б"), Range(0, 10)]
        private float _timeMovement;

        [SerializeField, Header("Размера при старте движения")]
        private Vector3 _scaleStart;

        [SerializeField, Header("Размер при конце движени")]
        private Vector3 _scaleEnd;

        [SerializeField] private Camera _camera;

        private GameObject _objKeyAnimation;

        public void AnimationRun(Transform objKey, KeyStatus selectedKey)
        {
            AnimationOfMovementToTransmittedKey(objKey, selectedKey);
        }

        private void Start()
        {
            _objKeyAnimation = _rectKeyAnimation.gameObject;
            ChangeConditionKeyAnimation(false);
            DOTween.Init();
        }

        private void AnimationOfMovementToTransmittedKey(Transform objKey, KeyStatus selectedKey)
        {
            ChangeConditionKeyAnimation(true);
            Vector3 viewportObjKeyPosition = _camera.WorldToViewportPoint(objKey.position);
            var newAnchors = MyUtils.GetAnchorsForAnObjectInViewport(viewportObjKeyPosition, _rectKeyAnimation);

            _rectKeyAnimation.anchorMin = newAnchors.min;
            _rectKeyAnimation.anchorMax = newAnchors.max;

            _rectKeyAnimation.localScale = _scaleStart;
            _rectKeyAnimation.DOAnchorMax(selectedKey.Rect.anchorMax, _timeMovement)
                .OnComplete(() => ChangeConditionKeyAnimation(false));
            _rectKeyAnimation.DOAnchorMin(selectedKey.Rect.anchorMin, _timeMovement)
                .OnComplete(selectedKey.ChangeSprite);
            _rectKeyAnimation.DOScale(_scaleEnd, _timeResize);
        }

        private void ChangeConditionKeyAnimation(bool condition)
        {
            _objKeyAnimation.SetActive(condition);
        }
    }
}