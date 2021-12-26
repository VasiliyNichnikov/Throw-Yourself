using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    [RequireComponent(typeof(DoubleTapOnScreen), typeof(DirectionalArrowControl))]
    public class InteractionWithScreen : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public Vector2 PositionStart => _positionStart;
        public Vector2 PositionEnd => _positionEnd;

        private Vector2 _positionStart;
        private Vector2 _positionEnd;
        
        // private InteractionWithScreenEvents _screenEvents;

        // private TouchPositions _touchPositions;
        private DoubleTapOnScreen _doubleTap;
        // private DirectionalArrowControl _arrowControl;


        public void OnPointerDown(PointerEventData eventData)
        {
            _positionStart = eventData.position;
            _positionEnd = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _positionEnd = eventData.position;
            _doubleTap.Click();
            // _doubleTap.Click();
            // var doubleClick = _doubleTap.IsDoubleClickComplete;
            // if (doubleClick)
            // {
            //     // _eventMovingToAnotherObject.Glow.Invoke(1);
            // }
            //
            // SelectArrow(doubleClick);
            // RotationDirectionsMovement();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // _firstMovement = true;
            // _oneClick = false;
            // var doubleClick = _doubleTap.GetStateDoubleClickAndReset();
            // if (doubleClick)
            // {
            //     _eventMovingToAnotherObject.Glow.Invoke(0);
            //     ChangeBody();
            // }
            // else
            // {
            //     MoveObjects();
            // }
            //
            // _selectedPlayer.Player.InteractionArrow.Remove();
        }

        private void Start()
        {
            _doubleTap = GetComponent<DoubleTapOnScreen>();
            // _screenEvents = new InteractionWithScreenEvents();
        }
    }
}