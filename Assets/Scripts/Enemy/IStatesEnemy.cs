namespace Enemy
{
    public interface IStatesEnemy
    {
        StateEnemy Idle { get; }
        StateEnemy MovementBehindPlayer { get; }
        StateEnemy MovementToSelectedPoint { get; }
        StateEnemy Attack { get; }

        void Init(ParentEnemy enemy, StateMachineEnemy stateMachine);
    }
}