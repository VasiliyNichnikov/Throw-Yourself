using System;
using UnityEngine;

namespace Enemy.Rifle
{
    public class EnemyRifle : ParentEnemy
    {
        private ParametersEnemyRifle _mainParameters;
        private TypeMovementObject _typeObject;

        public override void Attack()
        {
            base.Attack();
            if (_mainParameters.Timer.IsLaunched == false)
            {
                Vector3 thisPosition = ThisTransform.position;
                Vector3 playerPosition = _mainParameters.TransformPlayer.position;

                Vector3 direction = playerPosition -
                                    new Vector3(thisPosition.x, _mainParameters.PositionCreateBullet.y, thisPosition.z);
                float angleY = Vector3.Angle(direction, Vector3.right);
                angleY = direction.z < 0 ? angleY : -angleY;
                _mainParameters.Gun.Shoot(_mainParameters.PositionCreateBullet, direction,
                    _mainParameters.Settings.DamageWhenAttacking);
                BasicParameters.CreatorOfParticulars.Create(_mainParameters.ParticleShooting,
                    _mainParameters.PositionCreateBullet, Quaternion.Euler(0, angleY, 0));
                BasicParameters.CreatorPlayerSound.Create(BasicParameters.AttackPlayer, 0.1f);
                StartCoroutine(_mainParameters.Timer.ToRun(_mainParameters.Settings.DelayAttack));
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
                    target = _mainParameters.TransformPlayer.position;
                    stoppingDistance = _mainParameters.Settings.MinStoppingDistance;
                    break;
                case TypeMovementObject.SelectedPoint:
                    target = _mainParameters.SelectedPoint;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeObj), typeObj, null);
            }

            CheckingTransitionBetweenPoints();
            _mainParameters.Agent.stoppingDistance = stoppingDistance;
            _mainParameters.Agent.SetDestination(target);
        }

        public override void ChangeLocalRotationArmatureWithLerp(float angleY)
        {
            Quaternion newRotation = Quaternion.Euler(0, angleY, 0);
            _mainParameters.Armature.localRotation = Quaternion.Lerp(_mainParameters.Armature.localRotation,
                newRotation,
                Time.deltaTime * _mainParameters.Settings.SpeedRotation);
        }

        public override void Start()
        {
            SettingUpAnimations = new SettingUpAnimationsEnemyRifle(this);
            _mainParameters = GetComponent<ParametersEnemyRifle>();
            base.Start();
        }

        private void CheckingTransitionBetweenPoints()
        {
            if (_typeObject == TypeMovementObject.SelectedPoint
                && _mainParameters.DistanceFromSelectedPointToEnemy < _mainParameters.Settings.MinSelectedPointDistance)
            {
                _mainParameters.GoToNextPoint();
            }
        }
    }
}