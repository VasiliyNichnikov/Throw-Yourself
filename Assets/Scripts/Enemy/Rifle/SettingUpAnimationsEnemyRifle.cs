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
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0.0f);
            Enemy.Animator.SetBool(AnimatorStaticData.Shoot, false);
        }

        public override void LauncherMovementBehindPlayer()
        {
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.Animator.SetBool(AnimatorStaticData.Shoot, false);
        }

        public override void LauncherMovementToSelectedPoint()
        {
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.Animator.SetBool(AnimatorStaticData.Shoot, false);
        }

        public override void LauncherAttack()
        {
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0.0f);
            Enemy.Animator.SetBool(AnimatorStaticData.Shoot, true);
        }
    }
}