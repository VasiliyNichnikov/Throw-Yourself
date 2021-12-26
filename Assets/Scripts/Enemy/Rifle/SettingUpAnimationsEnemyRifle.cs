using Enemy.AnimatorData;

namespace Enemy.Rifle
{
    public class SettingUpAnimationsEnemyRifle : SettingUpAnimations
    {
        public SettingUpAnimationsEnemyRifle(ParentEnemy enemy) : base(enemy)
        {
        }

        public override void LauncherIdle()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0.0f);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Shoot, false);
        }

        public override void LauncherMovementBehindPlayer()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Shoot, false);
        }

        public override void LauncherMovementToSelectedPoint()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Shoot, false);
        }

        public override void LauncherAttack()
        {
            Enemy.BasicParameters.Animator.SetFloat(AnimatorStaticData.Speed, 0.0f);
            Enemy.BasicParameters.Animator.SetBool(AnimatorStaticData.Shoot, true);
        }
    }
}