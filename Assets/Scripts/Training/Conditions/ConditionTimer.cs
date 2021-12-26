using UnityEngine;

namespace Training.Conditions
{
    public class ConditionTimer : TransitionCondition
    {
        [SerializeField, Range(0, 10)] private float _delay;
        private Timer _timer;
        private bool _timerRunning;

        private void Start()
        {
            _timer = new Timer();
        }
        
        public override bool CheckingTransitionCondition()
        {
            if (_timer.IsLaunched == false && _timerRunning == false)
            {
                StartCoroutine(_timer.ToRun(_delay));
                _timerRunning = true;
            }

            return _timer.IsLaunched == false;
        }
    }
}