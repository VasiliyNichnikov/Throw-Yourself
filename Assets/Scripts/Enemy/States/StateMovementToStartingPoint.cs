namespace Enemy.States
{
    public class StateMovementToStartingPoint : StateEnemy
    {
        public StateMovementToStartingPoint(ParentEnemy enemy, StateMachineEnemy stateMachine) : base(enemy,
            stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Enemy.BasicSettings.PlayerIsNoticed = false;
            Enemy.IsMovementToSelectedPoint = true;
            Enemy.ChangeConditionAgentStop(false);
            Enemy.SettingUpAnimations.LauncherMovementToSelectedPoint();
        }

        public override void ActionsUpdate()
        {
            base.ActionsUpdate();
            Enemy.Move(TypeMovementObject.StartPosition);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Enemy.IsGoToIdle())
            {
                StateMachine.ChangeState(Enemy.States.Idle);
            }
            // else if (Enemy.IsGoToAttack())
            // {
            //     StateMachine.ChangeState(Enemy.States.Attack);
            // }
            else if (Enemy.IsGoToBehindPlayer())
            {
                StateMachine.ChangeState(Enemy.States.MovementBehindPlayer);
            }
        }

        public override void Exit()
        {
            base.Exit();
            Enemy.IsMovementToSelectedPoint = false;
        }
    }
}