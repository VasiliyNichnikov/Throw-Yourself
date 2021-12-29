using Player;
using UnityEngine;

namespace MainCamera
{
    [RequireComponent(typeof(CalculatorCameraPosition))]
    public class MovementOfCameraBehindObject : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _speed;
        private SelectedPlayer _player;
        private Transform _thisTransform;
        private CalculatorCameraPosition _calculatorPosition;

        private void Start()
        {
            _thisTransform = transform;
            _player = FindObjectOfType<SelectedPlayer>();
            _calculatorPosition = GetComponent<CalculatorCameraPosition>();
        }
        private void Update()
        {
            var positionEnd = _calculatorPosition.GetMovementPosition(_player.Main.transform.position);
            _thisTransform.position = Vector3.Lerp(_thisTransform.position, positionEnd, _speed * Time.deltaTime);
        }
    }
}