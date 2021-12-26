namespace Enemy
{
    public class StateMachineEnemy
    {
        public StateEnemy CurrentState { get; private set; }

        public void Initialize(StateEnemy startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(StateEnemy newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}