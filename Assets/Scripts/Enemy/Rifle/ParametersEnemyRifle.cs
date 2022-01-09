using Particulars;
using UnityEngine;

namespace Enemy.Rifle
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Parameters/EnemyRifle", order = 0)]
    public class ParametersEnemyRifle : BasicParametersEnemy
    {
        public ActivatorParticle ParticleShooting => _particleShooting;
        public float HeightRoute => _heightRoute;
        public GameObject PrefabBullet => _prefabBullet;

        [SerializeField, Header("Скрипт для создания и активации частиц")]
        private ActivatorParticle _particleShooting;

        [SerializeField, Header("Префаб пули")]
        private GameObject _prefabBullet;

        [SerializeField, Range(0, 1), Header("Высота на которой находится путь")]
        private float _heightRoute;
    }
}