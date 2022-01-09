using System;
using UnityEngine;

namespace Enemy.Rifle
{
    public class EnemyRifle : ParentEnemy
    {
        public Vector3 SelectedPoint =>
            new Vector3(_route.SelectedPoint.x, _settings.HeightRoute, _route.SelectedPoint.z);

        public float DistanceFromSelectedPointToEnemy =>
            Vector3.Distance(ThisTransform.position, _route.SelectedPoint);

        [SerializeField, Header("Точка, в которой будет создана пуля")]
        private Transform _pointCreateBullet;

        [SerializeField, Header("Путь по которому ходит враг")]
        private EnemyRoute _route;

        [SerializeField] private Transform _armature;

        private ShootingAtPlayerEnemyRifle _gun;
        private ParametersEnemyRifle _settings;
        private TypeMovementObject _typeObject;

        public override void Attack()
        {
            base.Attack();
            if (Timer.IsLaunched == false)
            {
                Vector3 thisPosition = ThisTransform.position;
                Vector3 playerPosition = _settings.TransformPlayer.position;
                Vector3 positionBullet = _pointCreateBullet.position;

                Vector3 direction = playerPosition -
                                    new Vector3(thisPosition.x, positionBullet.y, thisPosition.z);
                float angleY = Vector3.Angle(direction, Vector3.right);
                angleY = direction.z < 0 ? angleY : -angleY;
                _gun.Shoot(_settings.PrefabBullet, positionBullet, direction, _settings.DamageWhenAttacking);
                _settings.CreatorOfParticulars.Create(_settings.ParticleShooting, positionBullet,
                    Quaternion.Euler(0, angleY, 0));
                _settings.CreatorPlayerSound.Create(_settings.AttackSound, 0.1f);
                StartCoroutine(Timer.ToRun(_settings.DelayAttack));
            }
        }

        public override void Move(TypeMovementObject typeObj)
        {
            _typeObject = typeObj;
            float stoppingDistance = 0;
            Vector3 target;
            switch (typeObj)
            {
                case TypeMovementObject.Player:
                    target = _settings.TransformPlayer.position;
                    stoppingDistance = _settings.MinStoppingDistance;
                    break;
                case TypeMovementObject.SelectedPoint:
                    target = SelectedPoint;
                    break;
                case TypeMovementObject.StartPosition:
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeObj), typeObj, null);
            }

            CheckingTransitionBetweenPoints();
            Agent.stoppingDistance = stoppingDistance;
            Agent.SetDestination(target);
        }

        public override void ChangeLocalRotationArmatureWithLerp(float angleY)
        {
            Quaternion newRotation = Quaternion.Euler(0, angleY, 0);
            _armature.localRotation = Quaternion.Lerp(_armature.localRotation, newRotation,
                Time.deltaTime * _settings.SpeedRotation);
        }

        private void GoToNextPoint()
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

        public override void Start()
        {
            _settings = BasicSettings as ParametersEnemyRifle;
            SettingUpAnimations = new SettingUpAnimationsEnemyRifle(this);
            _gun = GetComponent<ShootingAtPlayerEnemyRifle>();
            // _mainSettings = GetComponent<ParametersEnemyRifle>();
            base.Start();
        }

        private void CheckingTransitionBetweenPoints()
        {
            if (_typeObject == TypeMovementObject.SelectedPoint
                && DistanceFromSelectedPointToEnemy < _settings.MinSelectedPointDistance)
            {
                GoToNextPoint();
            }
        }
    }
}