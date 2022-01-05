using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Key
{
    public class MovingToTheUserInterface : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectIconKey;
        [SerializeField] private RectTransform _rectAssembledKey;
        [SerializeField] private Transform _keyObject;

        [FormerlySerializedAs("_animationTime")] [SerializeField, Range(0, 5)]
        private float _animationTimeMovement;
        [SerializeField, Range(0, 5)] private float _animationTimeResize;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            DOTween.Init();
        }

        // private void Update()
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         AnimationKey();
        //     }
        // }

        private void AnimationKey()
        {
            // Выставление ключа UI на уровне объекта на сцене
            Vector3 viewportKeyObjectPosition = _camera.WorldToViewportPoint(_keyObject.position);
            var newAnchors = MyUtils.GetAnchorsForAnObjectInViewport(viewportKeyObjectPosition, _rectAssembledKey);
            _rectAssembledKey.anchorMin = newAnchors.min;
            _rectAssembledKey.anchorMax = newAnchors.max;
            Vector3 scaleStart = new Vector3(0, 0, 1);
            _rectAssembledKey.localScale = scaleStart;
            // Анимация ключа
            Vector3 scaleEnd = new Vector3(1, 1, 1);
            _rectAssembledKey.DOAnchorMax(_rectIconKey.anchorMax, _animationTimeMovement);
            _rectAssembledKey.DOAnchorMin(_rectIconKey.anchorMin, _animationTimeMovement);
            _rectAssembledKey.DOScale(scaleEnd, _animationTimeResize);
        }
    }
}