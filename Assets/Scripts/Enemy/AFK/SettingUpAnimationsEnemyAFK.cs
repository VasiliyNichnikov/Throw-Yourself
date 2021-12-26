using Enemy.AnimatorData;

namespace Enemy.AFK
{
    public class SettingUpAnimationsEnemyAFK : SettingUpAnimations
    {
        public SettingUpAnimationsEnemyAFK(ParentEnemy enemy) : base(enemy)
        {
        }

        public override void LauncherIdle()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Punch, false);
        }

        public override void LauncherMovementBehindPlayer()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Punch, false);
        }

        public override void LauncherMovementToSelectedPoint()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Punch, false);
        }

        public override void LauncherAttack()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0.0f);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Punch, true);
        }
    }
}