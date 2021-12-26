namespace Training.States
{
    public abstract class StateTraining
    {
        protected ParentTraining Training;
        protected StateMachineTraining StateMachine;
        protected ManagerTraining Manager;

        protected StateTraining(ParentTraining training, StateMachineTraining stateMachine, ManagerTraining manager)
        {
            Training = training;
            StateMachine = stateMachine;
            Manager = manager;
        }

        public virtual void Action()
        {
        }
        

        public virtual void LogicUpdate()
        {
        }
    }
}