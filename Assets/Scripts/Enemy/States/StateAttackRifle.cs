namespace Enemy.States
{
    public class StateAttackRifle : StateEnemy
    {
        public StateAttackRifle(ParentEnemy enemy, StateMachineEnemy stateMachine) : base(enemy, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Enemy.IsAttack = true;
            Enemy.ChangeConditionAgentStop(true);
            Enemy.SettingUpAnimations.LauncherAttack();
        }

        public override void ActionsUpdate()
        {
            base.ActionsUpdate();
            Enemy.ChangeRotationWithLerp();
            Enemy.ChangeLocalRotationArmatureWithLerp(30);
            Enemy.Attack();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Enemy.IsGoToSelectedPointFromAttack())
            {
                StateMachine.ChangeState(Enemy.States.MovementToSelectedPoint);
            }
            else if (Enemy.IsGoToBehindPlayerFromAttack())
            {
                StateMachine.ChangeState(Enemy.States.MovementBehindPlayer);
            }
        }

        public override void Exit()
        {
            base.Exit();
            Enemy.ChangeConditionAgentStop(false);
            Enemy.IsAttack = false;
        }
    }
}