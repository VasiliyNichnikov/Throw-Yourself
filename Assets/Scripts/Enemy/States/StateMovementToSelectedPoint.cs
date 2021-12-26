namespace Enemy.States
{
    public class StateMovementToSelectedPoint : StateEnemy
    {
        public StateMovementToSelectedPoint(ParentEnemy enemy, StateMachineEnemy stateMachine) :
            base(enemy, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Enemy.BasicParameters.PlayerIsNoticed = false;
            Enemy.IsMovementToSelectedPoint = true;
            Enemy.ChangeConditionAgentStop(false);
            Enemy.SettingUpAnimations.LauncherMovementToSelectedPoint();
        }

        public override void ActionsUpdate()
        {
            base.ActionsUpdate();
            Enemy.ChangeLocalRotationArmatureWithLerp(0);
            Enemy.Move(TypeMovementObject.SelectedPoint);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Enemy.IsGoToBehindPlayer())
            {
                StateMachine.ChangeState(Enemy.States.MovementBehindPlayer);
            }
            // else if (Enemy.IsGoToAttack())
            // {
            //     StateMachine.ChangeState(Enemy.States.Attack);
            // }
        }

        public override void Exit()
        {
            base.Exit();
            Enemy.IsMovementToSelectedPoint = false;
        }
    }
}