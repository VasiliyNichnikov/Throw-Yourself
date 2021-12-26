namespace Enemy
{
    public abstract class StateEnemy
    {
        protected ParentEnemy Enemy;
        protected StateMachineEnemy StateMachine;

        protected StateEnemy(ParentEnemy enemy, StateMachineEnemy stateMachine)
        {
            Enemy = enemy;
            StateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void ActionsUpdate()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void Exit()
        {
        }
    }
}