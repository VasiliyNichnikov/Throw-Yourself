using DirectionMovement;
using Events;
using MovingToAnotherObject;
using PhysicsObjects;
using Player;
using Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    [RequireComponent(typeof(DoubleTapOnScreen))]
    public class MotionHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public bool FirstMovement => _firstMovement;

        [SerializeField] private Camera _camera;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private PlayerMovementSound _movementSound;
        [SerializeField, Range(1, 50)] private float _sensitivity;

        private bool _oneClick;
        private DoubleTapOnScreen _doubleTap;
        private SelectedPlayer _selectedPlayer;
        private MotionVectorCalculator _vectorCalculator;
        private Events.MovingToAnotherObject _eventMovingToAnotherObject;

        private bool _firstMovement;
        private Vector3 _positionStart;
        private Vector3 _positionEnd;

        private void Start()
        {
            _eventMovingToAnotherObject = FindObjectOfType<EventKeeper>().MovingToAnotherObject;
            _vectorCalculator = new MotionVectorCalculator(_camera, _sensitivity);
            _doubleTap = GetComponent<DoubleTapOnScreen>();
            _selectedPlayer = FindObjectOfType<SelectedPlayer>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _positionStart = eventData.position;
            _positionEnd = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _positionEnd = eventData.position;
            var doubleClick = _doubleTap.IsDoubleClickComplete;
            if (doubleClick)
            {
                _eventMovingToAnotherObject.Glow.Invoke(1);
            }

            SelectArrow(doubleClick);
            RotationDirectionsMovement();
        }

        private void SelectArrow(bool doubleClick)
        {
            if (_oneClick == false)
            {
                _oneClick = true;
                TypesArrow typeArrow = TypesArrow.MotionSelection;
                if (doubleClick)
                {
                    typeArrow = TypesArrow.Transformation;
                }

                _selectedPlayer.Player.InteractionArrow.Install(typeArrow);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _firstMovement = true;
            _oneClick = false;
            var doubleClick = _doubleTap.GetStateDoubleClickAndReset();
            if (doubleClick)
            {
                _eventMovingToAnotherObject.Glow.Invoke(0);
                ChangeBody();
            }
            else
            {
                MoveObjects();
            }

            _selectedPlayer.Player.InteractionArrow.Remove();
        }

        private void RotationDirectionsMovement()
        {
            Vector3 direction = _vectorCalculator.GetDirectionsFromScreen(_positionStart, _positionEnd);
            // Выбор нового тела
            _selectedPlayer.Player.BodySwitch.BeamThrow(direction);
            // Работа со стрелкой
            _selectedPlayer.Player.InteractionArrow.ChangePosition();
            _selectedPlayer.Player.InteractionArrow.ChangeAngleZ(direction);
            _selectedPlayer.Player.InteractionArrow.Stretch(direction);
            _selectedPlayer.Player.InteractionArrow.SetVisible(true);
        }

        private void MoveObjects()
        {
            _movementSound.LauncherPlayback();
            Vector3 direction = _vectorCalculator.GetDirectionsFromScreen(_positionStart, _positionEnd);
            _selectedPlayer.Player.Movement.Push(direction);
        }

        private void ChangeBody()
        {
            _selectedPlayer.Player.BodySwitch.MoveToNew();
        }

        private void OnDrawGizmos()
        {
            if (_camera == null || _canvas == null) return;
            Vector3 start = GetWorldPosition(_positionStart);
            Vector3 end = GetWorldPosition(_positionEnd);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(start, 0.01f);
            Gizmos.DrawSphere(end, 0.01f);
            Gizmos.DrawLine(start, end);
        }

        private Vector3 GetWorldPosition(Vector3 screen)
        {
            Vector3 newPosition = new Vector3(screen.x, screen.y, _canvas.planeDistance);
            return _camera.ScreenToWorldPoint(newPosition);
        }
    }
}