using DirectionMovement;
using Events;
using UnityEngine;

namespace Interaction
{
    public class ScreenTapHandler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField, Range(1, 50)] private float _sensitivity;
        private Events.MovingToAnotherObject _eventMovingToAnotherObject;
        private MotionVectorCalculator _directionCalculator;
        private DirectionalArrowControl _arrowControl;
        private LearningSwitch _learningSwitch;
        private PlayerControl _playerControl;
        private bool _pointerHasBeenCreated;
        private bool _isDrag;
        private bool _firstTouch;


        public void OnDown()
        {
            print("Down");
            if (_firstTouch) return;
            _learningSwitch.LaunchGame();
            _firstTouch = true;
        }

        public void OnDrag(bool doubleClick, Vector3 positionStart, Vector3 positionEnd)
        {
            if (doubleClick)
            {
                _eventMovingToAnotherObject.Glow.Invoke(1);
            }

            Vector3 direction = _directionCalculator.GetDirectionsFromScreen(positionStart, positionEnd);
            LaunchingActionsArrow(doubleClick, direction);
        }

        public void OnUp(bool doubleClick, Vector3 positionStart, Vector3 positionEnd)
        {
            _pointerHasBeenCreated = false;
            Vector3 direction = _directionCalculator.GetDirectionsFromScreen(positionStart, positionEnd);
            if (doubleClick)
            {
                _eventMovingToAnotherObject.Glow.Invoke(0);
                ChangeBodyPlayer(direction);
            }
            else
            {
                MovePlayer(direction);
            }

            _arrowControl.Remove();
        }

        public void OnDrag(Vector3 positionStart, Vector3 positionEnd)
        {
            _isDrag = true;
            Vector3 direction = _directionCalculator.GetDirectionsFromScreen(positionStart, positionEnd);
            LaunchingActionsArrow(direction);
        }

        public void OnUp(Vector3 positionStart, Vector3 positionEnd)
        {
            _pointerHasBeenCreated = false;
            Vector3 direction = _directionCalculator.GetDirectionsFromScreen(positionStart, positionEnd);
            MovePlayer(direction);
            _arrowControl.ResetArrow();
            _arrowControl.Hide(direction);
            _isDrag = false;
        }

        private void LaunchingActionsArrow(bool doubleClick, Vector3 direction)
        {
            if (_pointerHasBeenCreated == false)
            {
                TypesArrow type = GettingTypeArrow.Get(doubleClick);
                _arrowControl.ToCreate(type);
                _pointerHasBeenCreated = true;
            }

            _arrowControl.Move();
            _arrowControl.Rotate(direction);
            _arrowControl.Stretch(direction);
            _arrowControl.Show();
        }

        private void LaunchingActionsArrow(Vector3 direction)
        {
            _arrowControl.Move();
            _arrowControl.Rotate(direction);
            _arrowControl.Stretch(direction);
            _arrowControl.Show();
        }

        private void MovePlayer(Vector3 direction)
        {
            if (_isDrag == false) return;
            _playerControl.Push(direction);
        }

        private void ChangeBodyPlayer(Vector3 direction)
        {
            _arrowControl.LaunchDisplacementBeam(direction);
            _playerControl.ChangeBody();
        }

        private void Start()
        {
            _eventMovingToAnotherObject = FindObjectOfType<EventKeeper>().MovingToAnotherObject;
            _arrowControl = GetComponent<DirectionalArrowControl>();
            _playerControl = GetComponent<PlayerControl>();
            _learningSwitch = GetComponent<LearningSwitch>();
            _directionCalculator = new MotionVectorCalculator(_camera, _sensitivity);
            InitArrow();
        }

        private void InitArrow()
        {
            _arrowControl.ToCreate(TypesArrow.MotionSelection);
            _arrowControl.Hide(Vector3.zero);
        }
    }
}