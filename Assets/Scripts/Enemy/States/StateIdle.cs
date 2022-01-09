namespace Enemy.States
{
    public class StateIdle : StateEnemy
    {
        public StateIdle(ParentEnemy enemy, StateMachineEnemy stateMachine) : base(enemy, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Enemy.IsIdle = true;
            Enemy.BasicSettings.PlayerIsNoticed = false;
            Enemy.ChangeConditionAgentStop(true);
            Enemy.ChangeRotationFieldOfView(true);
            Enemy.SettingUpAnimations.LauncherIdle();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Enemy.IsGoToBehindPlayer())
            {
                StateMachine.ChangeState(Enemy.States.MovementBehindPlayer);
            }
        }

        public override void Exit()
        {
            base.Exit();
            Enemy.IsIdle = false;
            Enemy.ChangeConditionAgentStop(false);
            Enemy.ChangeRotationFieldOfView(false);
        }
    }
}