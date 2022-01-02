using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Parameters/Enemy", order = 0)]
    public class ParametersEnemy : ScriptableObject
    {
        public string Name => _name;
        public float SpeedRotation => _speedRotation;
        public float MinWalkingDistance => _minWalkingDistance;
        public float MaxAttackDistance => _maxAttackDistance;
        public float MinSelectedPointDistance => _minSelectedPointDistance;
        public float DelayAttack => _delayAttack;
        public float DamageWhenAttacking => _damageWhenAttacking;
        public bool KeyIsEnemy => _keyIsEnemy;
        public float MinStoppingDistance => _minStoppingDistance;

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

        [SerializeField, Range(0, 100), Tooltip("Враг начнет аттаковать, когда расстояние станет меньше")]
        private float _maxAttackDistance;

        [SerializeField, Range(0, 10), Tooltip("Враг будет идти до выбранной точки пока расстояние не станет меньше")]
        private float _minSelectedPointDistance;

        [SerializeField, Range(0, 10), Header("Задержка между атаками")]
        private float _delayAttack;

        [SerializeField, Range(0, 100), Header("Урон наносимый при атаке")]
        private float _damageWhenAttacking;
    }
}