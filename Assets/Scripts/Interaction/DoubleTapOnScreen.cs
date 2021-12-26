using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    public class DoubleTapOnScreen : MonoBehaviour, IPointerDownHandler
    {
        public bool IsDoubleClickComplete => _isDoubleClickComplete;
        [SerializeField, Range(0, 1)] private float _delay;
        [SerializeField, Range(0, 1)] private float _minDistance;
        private Camera _camera;
        private Timer _timer;
        private float _countClick;
        private bool _isDoubleClickComplete;

        private void Start()
        {
            _camera = Camera.main;
            _timer = new Timer();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_timer.IsLaunched == false)
            {
                StartCoroutine(_timer.ToRun(_delay));
                _countClick = 0;
            }

            _countClick++;

            if ((_countClick >= 2) == false) return;
            _isDoubleClickComplete = true;

                
        }

        public bool GetStateDoubleClickAndReset()
        {
            if (_isDoubleClickComplete == false) return false;
            _isDoubleClickComplete = false;
            return true;
        }
    }
}