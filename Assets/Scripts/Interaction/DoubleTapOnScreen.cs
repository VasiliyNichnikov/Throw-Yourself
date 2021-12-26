using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    public class DoubleTapOnScreen : MonoBehaviour
    {
        public bool IsDoubleClickComplete => _isDoubleClickComplete;
        [SerializeField, Range(0, 1)] private float _delay;
        private Timer _timer;
        private float _countClick;
        private bool _isDoubleClickComplete;

        public void Click()
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

        private void Start()
        {
            _timer = new Timer();
        }
    }
}