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
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(ManagementStateRagdoll))]
    [RequireComponent(typeof(DestroyerOfVisualizationComponents))]
    public abstract class BasicParametersEnemy : MonoBehaviour
    {
        public float DistanceFromSelectedPositionToEnemy => Vector3.Distance(ThisTransform.position, _startPoint);

        public float DistanceFromPlayerToEnemy => Vector3.Distance(ThisTransform.position, TransformPlayer.position);
        
        public Timer Timer => _timer;
        public Vector3 StartPoint => _startPoint;

        public bool PlayerInMotion => _selectedPlayer.Main.PlayerInMotion;
        public CreatorKey CreatorKey => _creatorKey;

        public Transform TransformPlayer =>
            _selectedPlayer.Main.GetComponent<Transform>(); // TODO слишком частые запросы к GetComponent

        public ParametersEnemy Settings => settings;
        public SelectedPlayer SelectedPlayer => _selectedPlayer;
        public CreatorPlayerSound CreatorPlayerSound => _creatorPlayerSound;
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
        [SerializeField] private RotationOfFieldOfView _rotationOfFieldOfView;
        [SerializeField] private GameObject _drawArea;
        private AnalyzerOfPlayerGettingIntoZone _analyzerOfPlayerGettingIntoZone;
        private FieldOfViewEnemy _fieldOfView;

        public void Init()
        {
            if (settings == null)
                throw new Exception("There is no component responsible for the parameters.");
            if (_drawArea == null)
                throw new Exception("There is no component DrawArea");
            ThisTransform = transform;
            _startPoint = ThisTransform.position;
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider>();
            _timer = new Timer();
            _stateRagdoll = GetComponent<ManagementStateRagdoll>();
            _analyzerOfPlayerGettingIntoZone = _drawArea.GetComponent<AnalyzerOfPlayerGettingIntoZone>();
            _fieldOfView = _drawArea.GetComponent<FieldOfViewEnemy>();
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