using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    [RequireComponent(typeof(PlayerControl), typeof(DirectionalArrowControl), typeof(ScreenTapHandler))]
    public class InteractionWithScreen : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public Vector2 PositionStart => _positionStart;
        public Vector2 PositionEnd => _positionEnd;

        private Vector2 _positionStart;
        private Vector2 _positionEnd;

        private ScreenTapHandler _tapHandler;


        public void OnPointerDown(PointerEventData eventData)
        {
            _positionStart = eventData.position;
            _positionEnd = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _positionEnd = eventData.position;
            _tapHandler.OnDrag(_positionStart, _positionEnd);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _tapHandler.OnUp(_positionStart, _positionEnd);
        }

        private void Start()
        {
            _tapHandler = GetComponent<ScreenTapHandler>();
        }
    }
}