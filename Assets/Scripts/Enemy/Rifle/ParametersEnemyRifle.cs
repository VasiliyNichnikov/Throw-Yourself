using Particulars;
using UnityEngine;

namespace Enemy.Rifle
{
    public class ParametersEnemyRifle : BasicParametersEnemy
    {
        public Vector3 SelectedPoint => _route.SelectedPoint;
        public Transform Armature => _armature;
        public ShootingAtPlayerEnemyRifle Gun => _gun;
        public ActivatorParticle ParticleShooting => _particleShooting;

        public float DistanceFromSelectedPointToEnemy =>
            Vector3.Distance(ThisTransform.position, _route.SelectedPoint);

        public Vector3 PositionCreateBullet => _pointCreateBullet.position;

        [SerializeField] private Transform _pointCreateBullet;
        [SerializeField] private EnemyRoute _route;
        [SerializeField] private Transform _armature;
        [SerializeField] private ActivatorParticle _particleShooting;
        private ShootingAtPlayerEnemyRifle _gun;

        private void Start()
        {
            _gun = GetComponent<ShootingAtPlayerEnemyRifle>();
        }

        public void GoToNextPoint()
        {
            if (_route.IndexSelectedPoint + 1 < _route.MovingPoints.Length)
            {
                _route.IndexSelectedPoint++;
            }
            else
            {
                _route.IndexSelectedPoint = 0;
            }
        }
    }
}