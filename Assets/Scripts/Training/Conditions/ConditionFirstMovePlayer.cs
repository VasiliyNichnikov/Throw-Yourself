using Interaction;

namespace Training.Conditions
{
    public class ConditionFirstMovePlayer : TransitionCondition
    {
        // private MotionHandler _motionHandler;
        //
        // private void Start()
        // {
        //     _motionHandler = GetComponent<MotionHandler>();
        // }

        public override bool CheckingTransitionCondition()
        {
            return false;
        }
    }
}