namespace Enemy.States
{
    public class StateMovementBehindPlayer : StateEnemy
    {
        public StateMovementBehindPlayer(ParentEnemy enemy, StateMachineEnemy stateMachine) : base(enemy, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Enemy.BasicParameters.PlayerIsNoticed = true;
            Enemy.IsMovementBehindPlayer = true;
            Enemy.ChangeConditionAgentStop(false);
            Enemy.SettingUpAnimations.LauncherMovementBehindPlayer();
        }

        public override void ActionsUpdate()
        {
            base.ActionsUpdate();
            Enemy.ChangeRotationWithLerp();
            Enemy.ChangeLocalRotationArmatureWithLerp(0);
            Enemy.Move(TypeMovementObject.Player);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Enemy.IsGoToSelectedPointFromMovementBehind())
            {
                StateMachine.ChangeState(Enemy.States.MovementToSelectedPoint);
            }
            else if (Enemy.IsGoToAttack())
            {
                StateMachine.ChangeState(Enemy.States.Attack);
            }
        }

        public override void Exit()
        {
            base.Exit();
            Enemy.IsMovementBehindPlayer = false;
        }
    }
}