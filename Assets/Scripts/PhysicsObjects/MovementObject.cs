using System.Collections;
using UnityEngine;

namespace PhysicsObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementObject : MonoBehaviour
    {
        public bool PlayerInMotion => _playerInMotion;
        [SerializeField, Header("Сила удара")] private float _speed;
        [SerializeField] private bool _playerInMotion;
        private IEnumerator _runningCheck;
        private Rigidbody _rb;

        public void Push(Vector3 direction)
        {
            _rb.AddForce(direction * _speed);

            StopCheckingPlayerMovement();
            _runningCheck = CheckingPlayerMovement();
            StartCoroutine(_runningCheck);
        }

        public void StopCheckingPlayerMovement(bool stopMotion=false)
        {
            if(_runningCheck != null)
                StopCoroutine(_runningCheck);
            if(stopMotion)
                _playerInMotion = false;
        }
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _playerInMotion = false;
        }

        private IEnumerator CheckingPlayerMovement()
        {
            _playerInMotion = true;
            yield return new WaitForSeconds(0.1f);
            while (_rb.velocity != Vector3.zero)
            {
                yield return new WaitForFixedUpdate();
            }
            _playerInMotion = false;
        }
        
    }
}