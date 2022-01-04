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
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0);
            Enemy.Animator.SetBool(AnimatorStaticData.Punch, false);
        }

        public override void LauncherMovementBehindPlayer()
        {
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.Animator.SetBool(AnimatorStaticData.Punch, false);
        }

        public override void LauncherMovementToSelectedPoint()
        {
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0.5f);
            Enemy.Animator.SetBool(AnimatorStaticData.Punch, false);
        }

        public override void LauncherAttack()
        {
            Enemy.Animator.SetFloat(AnimatorStaticData.Speed, 0.0f);
            Enemy.Animator.SetBool(AnimatorStaticData.Punch, true);
        }
    }
}