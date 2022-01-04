using System;
using Enemy.Dead;
using Enemy.FieldOfView;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(ManagementStateRagdoll))]
    [RequireComponent(typeof(DestroyerOfVisualizationComponents))]
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

        public BasicParametersEnemy BasicSettings => _basicSettings;
        public IStatesEnemy States => _states;
        public SettingUpAnimations SettingUpAnimations { get; protected set; }
        protected Timer Timer => _timer;
        protected Vector3 StartPoint => _startPoint;
        public Animator Animator => _animator;
        protected NavMeshAgent Agent => _agent;
        protected float DistanceFromSelectedPositionToEnemy => Vector3.Distance(ThisTransform.position, _startPoint);

        protected float DistanceFromPlayerToEnemy =>
            Vector3.Distance(ThisTransform.position, _basicSettings.TransformPlayer.position);

        // public Collider Collider => _collider;
        // public ManagementStateRagdoll StateRagdoll => _stateRagdoll;
        // public DestroyerOfVisualizationComponents DestroyerOfVisualization => _destroyerOfVisualization;
        protected Transform ThisTransform;
        [Space] [SerializeField] private GameObject _drawArea;

        [SerializeField, Header("Настройки врага")]
        private BasicParametersEnemy _basicSettings;
        [SerializeField, Header("Вращение поля, которое отвечает за обзор")] 
        private RotationOfFieldOfView _rotationOfFieldOfView;
        
        private Vector3 _startPoint;
        private NavMeshAgent _agent;
        private Animator _animator;
        private Collider _collider;
        private ManagementStateRagdoll _stateRagdoll;
        private DestroyerOfVisualizationComponents _destroyerOfVisualization;
        private Timer _timer;
        private IStatesEnemy _states;
        private AnalyzerOfPlayerGettingIntoZone _analyzerOfPlayerGettingIntoZone;
        
        private FieldOfViewEnemy _fieldOfView;
        private StateMachineEnemy _stateMachine;
        public abstract void Move(TypeMovementObject typeObj);

        public void ChangeConditionAgentStop(bool condition)
        {
            _agent.isStopped = condition;
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
            return _analyzerOfPlayerGettingIntoZone.InArea == false ||
                   _basicSettings.PlayerIsNoticed == false;
        }

        public virtual bool IsGoToSelectedPointFromAttack()
        {
            return _analyzerOfPlayerGettingIntoZone.InArea == false ||
                   _basicSettings.PlayerIsNoticed == false;
        }

        public virtual bool IsGoToAttack()
        {
            return DistanceFromPlayerToEnemy <= _basicSettings.MaxAttackDistance &&
                   _analyzerOfPlayerGettingIntoZone.InArea &&
                   _basicSettings.PlayerIsNoticed;
        }

        public virtual bool IsGoToBehindPlayer()
        {
            return _analyzerOfPlayerGettingIntoZone.InArea &&
                   _basicSettings.PlayerInMotion;
        }

        public virtual bool IsGoToBehindPlayerFromAttack()
        {
            return _analyzerOfPlayerGettingIntoZone.InArea &&
                   DistanceFromPlayerToEnemy > _basicSettings.MaxAttackDistance &&
                   _basicSettings.PlayerIsNoticed;
        }

        public void ChangeRotationWithLerp()
        {
            Quaternion newRotation =
                MyUtils.GetLookRotation(ThisTransform.position, _basicSettings.TransformPlayer.position);
            ThisTransform.rotation = Quaternion.Lerp(ThisTransform.rotation, newRotation,
                Time.deltaTime * _basicSettings.SpeedRotation);
        }

        public virtual void ChangeLocalRotationArmatureWithLerp(float angle)
        {
        }

        public void ChangeRotationFieldOfView(bool state)
        {
            _rotationOfFieldOfView.ChangeRotationState(state);
        }

        public void Death()
        {
            if (IsAlive == false) return;

            IsAlive = false;
            ChangeConditionAgentStop(true);
            _animator.enabled = false;
            CheckingKey();
            Destroy(_collider);
            _stateRagdoll.Destruction();
            _destroyerOfVisualization.Destruction();
        }

        private void CheckingKey()
        {
            if (BasicSettings.KeyIsEnemy)
            {
                BasicSettings.CreatorKey.Create(ThisTransform.position);
            }
        }

        public virtual void Start()
        {
            if (_drawArea == null)
                throw new Exception($"There is no component {nameof(GameObject)} (DrawArea)");

            IsAlive = true;
            ThisTransform = transform;
            _startPoint = ThisTransform.position;
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider>();
            _destroyerOfVisualization = GetComponent<DestroyerOfVisualizationComponents>();
            _timer = new Timer();
            _stateRagdoll = GetComponent<ManagementStateRagdoll>();
            _analyzerOfPlayerGettingIntoZone = _drawArea.GetComponent<AnalyzerOfPlayerGettingIntoZone>();
            _fieldOfView = _drawArea.GetComponent<FieldOfViewEnemy>();
            _fieldOfView.ViewDistance = _basicSettings.MinWalkingDistance;
            _states = GetComponent<IStatesEnemy>();
            _basicSettings.Init();
            _basicSettings.EventKeeper.EnemyEvents.ResetIsNoticesPlayer.AddListener(ResetPlayerIsNoticed);
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
            _basicSettings.PlayerIsNoticed = false;
        }

        private void Update()
        {
            if (!IsAlive) return;
            _stateMachine.CurrentState.ActionsUpdate();
            _stateMachine.CurrentState.LogicUpdate();
        }
    }
}