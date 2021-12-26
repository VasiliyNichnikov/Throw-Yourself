namespace Enemy
{
    public abstract class SettingUpAnimations
    {
        protected ParentEnemy Enemy;

        protected SettingUpAnimations(ParentEnemy enemy)
        {
            Enemy = enemy;
        }

        public abstract void LauncherIdle();

        public abstract void LauncherMovementBehindPlayer();

        public abstract void LauncherMovementToSelectedPoint();

        public abstract void LauncherAttack();
    }
}