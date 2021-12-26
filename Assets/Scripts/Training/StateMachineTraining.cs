using Training.States;

namespace Training
{
    public class StateMachineTraining
    {
        public StateTraining CurrentState { get; private set; }

        public void Initialize(StateTraining startingState)
        {
            CurrentState = startingState;
            startingState.Action();
        }

        public void ChangeState(StateTraining newState)
        {
            CurrentState = newState;
            newState.Action();
        }
    }
}