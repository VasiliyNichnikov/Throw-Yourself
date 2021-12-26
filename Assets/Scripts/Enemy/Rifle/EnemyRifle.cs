using System;
using UnityEngine;

namespace Enemy.Rifle
{
    public class EnemyRifle : ParentEnemy
    {
        private ParametersEnemyRifle _parameters;
        private TypeMovementObject _typeObject;

        public override void Attack()
        {
            base.Attack();
            if (_parameters.Timer.IsLaunched == false)
            {
                Vector3 thisPosition = ThisTransform.position;
                Vector3 playerPosition = _parameters.Player.position;
                
                Vector3 direction = playerPosition  - new Vector3(thisPosition.x, _parameters.PositionCreateBullet.y, thisPosition.z);
                float angleY = Vector3.Angle(direction, Vector3.right);
                angleY = direction.z < 0 ? angleY : -angleY;
                _parameters.Gun.Shoot(_parameters.PositionCreateBullet, direction, _parameters.DamagePlayerWhenAttacking);
                BasicParameters.CreatorOfParticulars.Create(_parameters.ParticleShooting, _parameters.PositionCreateBullet, Quaternion.Euler(0, angleY, 0));
                BasicParameters.CreatorPlayerSound.Create(BasicParameters.AttackPlayer, 0.1f);
                StartCoroutine(_parameters.Timer.ToRun(_parameters.DelayAttack));
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
                    target = _parameters.Player.position;
                    stoppingDistance = _parameters.MinStoppingDistance;
                    break;
                case TypeMovementObject.SelectedPoint:
                    target = _parameters.SelectedPoint;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeObj), typeObj, null);
            }

            CheckingTransitionBetweenPoints();
            _parameters.Agent.stoppingDistance = stoppingDistance;
            _parameters.Agent.SetDestination(target);
        }

        public override void ChangeLocalRotationArmatureWithLerp(float angleY)
        {
            Quaternion newRotation = Quaternion.Euler(0, angleY, 0);
            _parameters.Armature.localRotation = Quaternion.Lerp(_parameters.Armature.localRotation, newRotation,
                Time.deltaTime * _parameters.SpeedRotation);
        }

        public override void Start()
        {
            SettingUpAnimations = new SettingUpAnimationsEnemyRifle(this);
            _parameters = GetComponent<ParametersEnemyRifle>();
            base.Start();
        }

        private void CheckingTransitionBetweenPoints()
        {
            if (_typeObject == TypeMovementObject.SelectedPoint
                && _parameters.DistanceFromSelectedPointToEnemy < _parameters.MinDistanceToSelectedPoint)
            {
                _parameters.GoToNextPoint();
            }
        }
    }
}