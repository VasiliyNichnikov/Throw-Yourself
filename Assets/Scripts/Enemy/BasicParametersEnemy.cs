using System;
using Enemy.Dead;
using Enemy.FieldOfView;
using Events;
using Key;
using Particulars;
using Player;
using Sound;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent), typeof(ManagementStateRagdoll))]
    [RequireComponent(typeof(DestroyerOfVisualizationComponents))]
    public abstract class BasicParametersEnemy : MonoBehaviour
    {
        // public float SpeedRotation => _speedRotation;
        public float DistanceFromSelectedPositionToEnemy => Vector3.Distance(ThisTransform.position, _startPoint);

        public float DistanceFromPlayerToEnemy => Vector3.Distance(ThisTransform.position, TransformPlayer.position);

        // public float MinWalkingDistance => _minWalkingDistance;
        // public float MinAttackDistance => _minAttackDistance;
        // public float MinDistanceToSelectedPoint => _minDistanceToSelectedPoint;
        // public float DelayAttack => _delayAttack;
        // public float DamagePlayerWhenAttacking => _damagePlayerWhenAttacking;
        public Timer Timer => _timer;
        public Vector3 StartPoint => _startPoint;

        public bool PlayerInMotion => _selectedPlayer.Main.PlayerInMotion;

        // [HideInInspector] public bool PlayerIsNoticed;
        // public bool KeyIsEnemy => _keyIsEnemy;
        // public float MinStoppingDistance => _minStoppingDistance;
        public CreatorKey CreatorKey => _creatorKey;

        public Transform TransformPlayer =>
            _selectedPlayer.Main.GetComponent<Transform>(); // TODO слишком частые запросы к GetComponent

        public ParametersEnemy Settings => settings;
        public SelectedPlayer SelectedPlayer => _selectedPlayer;
        public CreatorPlayerSound CreatorPlayerSound => _creatorPlayerSound;
        public AudioClip AttackPlayer => _attackPlayer;
        public Animator Animator => _animator;
        public NavMeshAgent Agent => _agent;
        public Collider Collider => _collider;
        public EventKeeper EventKeeper => _eventKeeper;
        public ManagementStateRagdoll StateRagdoll => _stateRagdoll;
        public DestroyerOfVisualizationComponents DestroyerOfVisualization => _destroyerOfVisualization;
        public CreatorOfParticulars CreatorOfParticulars => _creatorOfParticulars;
        public RotationOfFieldOfView RotationOfFieldOfView => _rotationOfFieldOfView;
        public AnalyzerOfPlayerGettingIntoZone AnalyzerOfPlayerGettingIntoZone => _analyzerOfPlayerGettingIntoZone;
        protected Transform ThisTransform;

        [HideInInspector] public bool PlayerIsNoticed;
        // [SerializeField, Header("Находится ли ключ в этом враге")]
        // private bool _keyIsEnemy;
        //
        // [SerializeField, Range(1, 20), Tooltip("Скорость поворота")]
        // private float _speedRotation;
        //
        // [SerializeField, Range(0.1f, 10f), Tooltip("Минимальное расстояние до остановки")]
        // private float _minStoppingDistance;
        //
        // [SerializeField, Range(0, 100), Tooltip("Минимальное расстояние при котором враг будет следить за игроком")]
        // private float _minWalkingDistance;

        // [SerializeField, Range(0, 100), Tooltip("Минимальное расстояние при котором враг будет атаковать")]
        // private float _minAttackDistance;

        // [SerializeField, Range(0, 10), Tooltip("Минимальное расстояние при котором враг будет идти к выбранной точке")]
        // private float _minDistanceToSelectedPoint;

        // [SerializeField, Range(0, 10), Tooltip("Задержка между атаками")]
        // private float _delayAttack;

        // [SerializeField, Range(0, 100), Tooltip("Кол-во урона за одну атаку")]
        // private float _damagePlayerWhenAttacking;

        private SelectedPlayer _selectedPlayer;
        private Vector3 _startPoint;
        private NavMeshAgent _agent;
        private Animator _animator;
        private Collider _collider;
        private ManagementStateRagdoll _stateRagdoll;
        private DestroyerOfVisualizationComponents _destroyerOfVisualization;
        private Timer _timer;
        private CreatorOfParticulars _creatorOfParticulars;
        private CreatorKey _creatorKey;
        private CreatorPlayerSound _creatorPlayerSound;
        private EventKeeper _eventKeeper;

        [SerializeField] private ParametersEnemy settings;
        [SerializeField] private AudioClip _attackPlayer;
        [SerializeField] private RotationOfFieldOfView _rotationOfFieldOfView;
        [SerializeField] private AnalyzerOfPlayerGettingIntoZone _analyzerOfPlayerGettingIntoZone;
        [SerializeField] private FieldOfViewEnemy _fieldOfView;

        public void Init()
        {
            if (settings == null)
                throw new Exception("There is no component responsible for the parameters.");

            ThisTransform = transform;
            _startPoint = ThisTransform.position;
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider>();
            _timer = new Timer();
            _stateRagdoll = GetComponent<ManagementStateRagdoll>();
            _destroyerOfVisualization = GetComponent<DestroyerOfVisualizationComponents>();
            _selectedPlayer = FindObjectOfType<SelectedPlayer>();
            _creatorOfParticulars = FindObjectOfType<CreatorOfParticulars>();
            _creatorKey = FindObjectOfType<CreatorKey>();
            _creatorPlayerSound = FindObjectOfType<CreatorPlayerSound>();
            _eventKeeper = FindObjectOfType<EventKeeper>();
            _fieldOfView.ViewDistance = settings.MinWalkingDistance;
        }
    }
}