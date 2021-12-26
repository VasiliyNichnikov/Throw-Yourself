namespace Training.States
{
    public class StateAppearanceText : StateTraining
    {
        public StateAppearanceText(ParentTraining training, StateMachineTraining stateMachine, ManagerTraining manager)
            : base(training, stateMachine, manager)
        {
        }

        public override void Action()
        {
            base.Action();
            string newText = Manager.Text.TextRussian;
            Training.ChangeInfoInText(newText);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Manager.TransitionCondition == null)
            {
                Training.End();
                return;
            }

            bool makeTransition = Manager.TransitionCondition.CheckingTransitionCondition();
            if (makeTransition)
            {
                Training.NextState();
            }
        }
    }
}