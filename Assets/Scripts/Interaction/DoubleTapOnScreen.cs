using UnityEngine;


namespace Interaction
{
    public class DoubleTapOnScreen : MonoBehaviour
    {
        public bool IsDoubleClickNow => _isDoubleClickNow;
        [SerializeField, Range(0, 1)] private float _delay;
        private Timer _timer;
        private float _countClick;
        private bool _isDoubleClickNow;

        public void Click()
        {
            if (_timer.IsLaunched == false)
            {
                StartCoroutine(_timer.ToRun(_delay));
                _countClick = 0;
            }

            _countClick++;

            if ((_countClick >= 2) == false) return;
            _isDoubleClickNow = true;
        }

        public bool GetStateDoubleClickAndReset()
        {
            if (_isDoubleClickNow == false) return false;
            _isDoubleClickNow = false;
            return true;
        }

        private void Start()
        {
            _timer = new Timer();
        }
    }
}