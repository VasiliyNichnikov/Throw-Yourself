using MovingToAnotherObject;

namespace Training.Conditions
{
    public class ConditionRelocationToAnotherObject : TransitionCondition
    {
        private BodySwitchPlayer _bodySwitch;

        private void Start()
        {
            _bodySwitch = GetComponent<BodySwitchPlayer>();
        }
        
        public override bool CheckingTransitionCondition()
        {
            return _bodySwitch.FirstSwitchBody;
        }
    }
}