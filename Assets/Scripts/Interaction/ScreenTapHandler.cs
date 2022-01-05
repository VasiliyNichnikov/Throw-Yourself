using DirectionMovement;
using Events;
using Player;
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
        private PlayerControl _playerControl;
        private bool _firstDrag;

        public void OnDrag(bool doubleClick, Vector3 positionStart, Vector3 positionEnd)
        {
            if (doubleClick)
            {
                _eventMovingToAnotherObject.Glow.Invoke(1);
            }

            LaunchingActionsArrow(doubleClick, positionStart, positionEnd);
        }

        public void OnUp(bool doubleClick, Vector3 positionStart, Vector3 positionEnd)
        {
            _firstDrag = false;
            if (doubleClick)
            {
                _eventMovingToAnotherObject.Glow.Invoke(0);
                ChangeBodyPlayer();
            }
            else
            {
                MovePlayer(positionStart, positionEnd);
            }

            _arrowControl.Remove();
        }

        private void LaunchingActionsArrow(bool doubleClick, Vector3 positionStart, Vector3 positionEnd)
        {
            Vector3 direction = _directionCalculator.GetDirectionsFromScreen(positionStart, positionEnd);
            if (_firstDrag == false)
            {
                TypesArrow type = GettingTypeArrow.Get(doubleClick);
                _arrowControl.ToCreate(type);
                _firstDrag = true;
            }

            _arrowControl.Move();
            _arrowControl.Rotate(direction);
            _arrowControl.Stretch(direction);
            _arrowControl.LaunchDisplacementBeam(direction);
            _arrowControl.Show();
        }

        private void MovePlayer(Vector3 positionStart, Vector3 positionEnd)
        {
            Vector3 direction = _directionCalculator.GetDirectionsFromScreen(positionStart, positionEnd);
            _playerControl.Push(direction);
        }

        private void ChangeBodyPlayer()
        {
            _playerControl.ChangeBody();
        }

        private void Start()
        {
            _eventMovingToAnotherObject = FindObjectOfType<EventKeeper>().MovingToAnotherObject;
            _arrowControl = GetComponent<DirectionalArrowControl>();
            _playerControl = GetComponent<PlayerControl>();
            _directionCalculator = new MotionVectorCalculator(_camera, _sensitivity);
        }
    }
}