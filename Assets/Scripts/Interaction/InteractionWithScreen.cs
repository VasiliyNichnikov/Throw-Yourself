using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    [RequireComponent(typeof(DoubleTapOnScreen), typeof(DirectionalArrowControl), typeof(ScreenTapHandler))]
    [RequireComponent(typeof(PlayerControl))]
    public class InteractionWithScreen : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public Vector2 PositionStart => _positionStart;
        public Vector2 PositionEnd => _positionEnd;

        private Vector2 _positionStart;
        private Vector2 _positionEnd;

        private ScreenTapHandler _tapHandler;
        private DoubleTapOnScreen _doubleTap;


        public void OnPointerDown(PointerEventData eventData)
        {
            _positionStart = eventData.position;
            _positionEnd = eventData.position;
            _doubleTap.Click();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _positionEnd = eventData.position;
            var doubleClick = _doubleTap.IsDoubleClickNow;
            _tapHandler.OnDrag(doubleClick, _positionStart, _positionEnd);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            var doubleClick = _doubleTap.GetStateDoubleClickAndReset();
            _tapHandler.OnUp(doubleClick, _positionStart, _positionEnd);
        }

        private void Start()
        {
            _doubleTap = GetComponent<DoubleTapOnScreen>();
            _tapHandler = GetComponent<ScreenTapHandler>();
        }
    }
}