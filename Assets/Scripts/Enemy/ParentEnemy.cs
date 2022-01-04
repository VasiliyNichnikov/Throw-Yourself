using UnityEngine;

namespace Enemy
{
    public abstract class ParentEnemy : MonoBehaviour
    {
        public bool IsAlive { get; private set; }

        [Header("Враг в состояние Idle")] public bool IsIdle;

        [Header("Враг в состояние движения за игроком")]
        public bool IsMovementBehindPlayer;

        [Header("Враг в состояние движения к стартовой точке")]
        public bool IsMovementToSelectedPoint;

        [Header("Враг в состояние атаки руками по игроку")]
        public bool IsAttack;

        public BasicParametersEnemy BasicParameters => _basicParameters;
        public IStatesEnemy States => _states;
        public SettingUpAnimations SettingUpAnimations { get; protected set; }

        protected Transform ThisTransform;
        private IStatesEnemy _states;
        private StateMachineEnemy _stateMachine;
        private BasicParametersEnemy _basicParameters;
        public abstract void Move(TypeMovementObject typeObj);

        public void ChangeConditionAgentStop(bool condition)
        {
            _basicParameters.Agent.isStopped = condition;
        }

        public virtual void Attack()
        {
        }

        public virtual bool IsGoToIdle()
        {
            return false;
        }

        public virtual bool IsGoToSelectedPointFromMovementBehind()
        {
            return _basicParameters.AnalyzerOfPlayerGettingIntoZone.InArea == false ||
                   _basicParameters.PlayerIsNoticed == false;
        }

        public virtual bool IsGoToSelectedPointFromAttack()
        {
            return _basicParameters.AnalyzerOfPlayerGettingIntoZone.InArea == false ||
                   _basicParameters.PlayerIsNoticed == false;
        }

        public virtual bool IsGoToAttack()
        {
            return _basicParameters.DistanceFromPlayerToEnemy <= _basicParameters.Settings.MaxAttackDistance &&
                   _basicParameters.AnalyzerOfPlayerGettingIntoZone.InArea &&
                   _basicParameters.PlayerIsNoticed;
        }

        public virtual bool IsGoToBehindPlayer()
        {
            return _basicParameters.AnalyzerOfPlayerGettingIntoZone.InArea &&
                   _basicParameters.PlayerInMotion;
        }

        public virtual bool IsGoToBehindPlayerFromAttack()
        {
            return _basicParameters.AnalyzerOfPlayerGettingIntoZone.InArea &&
                   _basicParameters.DistanceFromPlayerToEnemy > _basicParameters.Settings.MaxAttackDistance &&
                   _basicParameters.PlayerIsNoticed;
        }

        public void ChangeRotationWithLerp()
        {
            Quaternion newRotation =
                MyUtils.GetLookRotation(ThisTransform.position, _basicParameters.TransformPlayer.position);
            ThisTransform.rotation = Quaternion.Lerp(ThisTransform.rotation, newRotation,
                Time.deltaTime * _basicParameters.Settings.SpeedRotation);
        }

        public virtual void ChangeLocalRotationArmatureWithLerp(float angle)
        {
        }

        public void ChangeRotationFieldOfView(bool state)
        {
            _basicParameters.RotationOfFieldOfView.ChangeRotationState(state);
        }

        public void Death()
        {
            if (IsAlive == false) return;

            IsAlive = false;
            ChangeConditionAgentStop(true);
            _basicParameters.Animator.enabled = false;
            CheckingKey();
            Destroy(_basicParameters.Collider);
            _basicParameters.StateRagdoll.Destruction();
            _basicParameters.DestroyerOfVisualization.Destruction();
        }

        private void CheckingKey()
        {
            if (BasicParameters.Settings.KeyIsEnemy)
            {
                BasicParameters.CreatorKey.Create(ThisTransform.position);
            }
        }

        public virtual void Start()
        {
            IsAlive = true;
            ThisTransform = transform;
            _states = GetComponent<IStatesEnemy>();
            _basicParameters = GetComponent<BasicParametersEnemy>();
            _basicParameters.Init();
            _basicParameters.EventKeeper.EnemyEvents.ResetIsNoticesPlayer.AddListener(ResetPlayerIsNoticed);
            InitStates();
        }

        private void InitStates()
        {
            _stateMachine = new StateMachineEnemy();
            _states.Init(this, _stateMachine);
            _stateMachine.Initialize(_states.Idle);
        }

        private void ResetPlayerIsNoticed()
        {
            _basicParameters.PlayerIsNoticed = false;
        }

        private void Update()
        {
            if (!IsAlive) return;
            _stateMachine.CurrentState.ActionsUpdate();
            _stateMachine.CurrentState.LogicUpdate();
        }
    }
}