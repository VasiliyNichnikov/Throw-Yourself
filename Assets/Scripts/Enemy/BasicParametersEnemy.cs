using Events;
using Key;
using Particulars;
using Player;
using Sound;
using UnityEngine;

namespace Enemy
{
    public abstract class BasicParametersEnemy : ScriptableObject
    {
        public string Name => _name;
        public float SpeedRotation => _speedRotation;
        public float MinWalkingDistance => _minWalkingDistance;
        public float MaxAttackDistance => _maxAttackDistance;
        public float MinSelectedPointDistance => _minSelectedPointDistance;
        public float DelayAttack => _delayAttack;
        public float DamageWhenAttacking => _damageWhenAttacking;
        public bool KeyIsEnemy => _keyIsEnemy;
        public AudioClip AttackSound => _attackSound;
        public float MinStoppingDistance => _minStoppingDistance;
        public bool PlayerInMotion => _selectedPlayer.Main.PlayerInMotion;
        public CreatorKey CreatorKey => _creatorKey;

        public Transform TransformPlayer =>
            _selectedPlayer.Main.GetComponent<Transform>(); // TODO слишком частые запросы к GetComponent
        
        public SelectedPlayer SelectedPlayer => _selectedPlayer;
        public CreatorPlayerSound CreatorPlayerSound => _creatorPlayerSound;
        public EventKeeper EventKeeper => _eventKeeper;
        public CreatorOfParticulars CreatorOfParticulars => _creatorOfParticulars;

        [HideInInspector] public bool PlayerIsNoticed;

        private SelectedPlayer _selectedPlayer;
        private CreatorOfParticulars _creatorOfParticulars;
        private CreatorKey _creatorKey;
        private CreatorPlayerSound _creatorPlayerSound;
        private EventKeeper _eventKeeper;

        [SerializeField, Header("Название параметра врага")]
        private string _name;

        [SerializeField, Header("Находится ли ключ в этом враге")]
        private bool _keyIsEnemy;

        [SerializeField, Range(1, 20), Header("Скорость вращения")]
        private float _speedRotation;

        [SerializeField, Range(0.1f, 10f), Tooltip("Враг не будет останавливаться, пока расстояние не станет меньше")]
        private float _minStoppingDistance;

        [SerializeField, Range(0, 100), Tooltip("Враг будет идти пока расстояние не станет меньше")]
        private float _minWalkingDistance;

        [SerializeField, Range(0, 10), Tooltip("Враг будет идти до выбранной точки пока расстояние не станет меньше")]
        private float _minSelectedPointDistance;

        [SerializeField, Header("Звук при атаке")]
        private AudioClip _attackSound;

        [SerializeField, Range(0, 100), Tooltip("Враг начнет аттаковать, когда расстояние станет меньше")]
        private float _maxAttackDistance;

        [SerializeField, Range(0, 10), Header("Задержка между атаками")]
        private float _delayAttack;

        [SerializeField, Range(0, 100), Header("Урон наносимый при атаке")]
        private float _damageWhenAttacking;

        public void Init()
        {
            _selectedPlayer = FindObjectOfType<SelectedPlayer>();
            _creatorOfParticulars = FindObjectOfType<CreatorOfParticulars>();
            _creatorKey = FindObjectOfType<CreatorKey>();
            _creatorPlayerSound = FindObjectOfType<CreatorPlayerSound>();
            _eventKeeper = FindObjectOfType<EventKeeper>();
        }
    }
}