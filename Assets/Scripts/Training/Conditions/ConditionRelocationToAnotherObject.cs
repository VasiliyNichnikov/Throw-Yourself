using MovingToAnotherObject;

namespace Training.Conditions
{
    public class ConditionRelocationToAnotherObject : TransitionCondition
    {
        private PlayerBodySwitch _bodySwitch;

        private void Start()
        {
            _bodySwitch = GetComponent<PlayerBodySwitch>();
        }
        
        public override bool CheckingTransitionCondition()
        {
            return _bodySwitch.FirstSwitchBody;
        }
    }
}