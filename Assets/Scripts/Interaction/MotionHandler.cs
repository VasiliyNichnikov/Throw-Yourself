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
    
    public class MotionHandler : MonoBehaviour
    {
        public bool FirstMovement => _firstMovement;

        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerMovementSound _movementSound;
        [SerializeField, Range(1, 50)] private float _sensitivity;

        private bool _oneClick;
        
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
            // _doubleTap = GetComponent<DoubleTapOnScreen>();
            _selectedPlayer = FindObjectOfType<SelectedPlayer>();
        }

        // public void OnPointerDown(PointerEventData eventData)
        // {
        //     _positionStart = eventData.position;
        //     _positionEnd = eventData.position;
        // }

        // public void OnDrag(PointerEventData eventData)
        // {
        //     _positionEnd = eventData.position;
        //     var doubleClick = _doubleTap.IsDoubleClickComplete;
        //     if (doubleClick)
        //     {
        //         _eventMovingToAnotherObject.Glow.Invoke(1);
        //     }
        //
        //     SelectArrow(doubleClick);
        //     RotationDirectionsMovement();
        // }

        // private void SelectArrow(bool doubleClick)
        // {
        //     if (_oneClick == false)
        //     {
        //         _oneClick = true;
        //         TypesArrow typeArrow = TypesArrow.MotionSelection;
        //         if (doubleClick)
        //         {
        //             typeArrow = TypesArrow.Transformation;
        //         }
        //
        //         _selectedPlayer.Player.InteractionArrow.Install(typeArrow);
        //     }
        // }

        // public void OnPointerUp(PointerEventData eventData)
        // {
        //     _firstMovement = true;
        //     _oneClick = false;
        //     var doubleClick = _doubleTap.GetStateDoubleClickAndReset();
        //     if (doubleClick)
        //     {
        //         _eventMovingToAnotherObject.Glow.Invoke(0);
        //         ChangeBody();
        //     }
        //     else
        //     {
        //         MoveObjects();
        //     }
        //
        //     _selectedPlayer.Player.InteractionArrow.Remove();
        // }

        private void RotationDirectionsMovement()
        {
            Vector3 direction = _vectorCalculator.GetDirectionsFromScreen(_positionStart, _positionEnd);
            // Выбор нового тела
            _selectedPlayer.Main.BodySwitch.BeamThrow(direction);
            // Работа со стрелкой
            _selectedPlayer.Main.InteractionArrow.ChangePosition();
            _selectedPlayer.Main.InteractionArrow.ChangeAngleZ(direction);
            _selectedPlayer.Main.InteractionArrow.Stretch(direction);
            _selectedPlayer.Main.InteractionArrow.SetVisible(true);
        }

        private void MoveObjects()
        {
            _movementSound.LauncherPlayback();
            Vector3 direction = _vectorCalculator.GetDirectionsFromScreen(_positionStart, _positionEnd);
            _selectedPlayer.Main.Movement.Push(direction);
        }

        private void ChangeBody()
        {
            _selectedPlayer.Main.BodySwitch.MoveToNew();
        }
    }
}