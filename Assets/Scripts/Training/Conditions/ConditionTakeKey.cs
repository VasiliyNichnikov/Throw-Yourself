namespace Training.Conditions
{
    public class ConditionTakeKey : TransitionCondition
    {
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GetComponent<GameManager>();
        }

        public override bool CheckingTransitionCondition()
        {
            return _gameManager.LevelCompleted;
        }
    }
}