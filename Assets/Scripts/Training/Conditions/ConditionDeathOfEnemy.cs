using Enemy;

namespace Training.Conditions
{
    public class ConditionDeathOfEnemy : TransitionCondition
    {
        private ParentEnemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<ParentEnemy>();
        }
        
        public override bool CheckingTransitionCondition()
        {
            return _enemy.IsAlive == false;
        }
    }
}