using System;
using LifeSlider;
using UnityEngine;

namespace Enemy.AFK
{
    public class EnemyAFK : ParentEnemy
    {
        private StatesEnemyAFK _states;
        private ParametersEnemyAFK _mainParameters;

        public override void Move(TypeMovementObject typeObj)
        {
            float stoppingDistance = 0;
            Vector3 target;
            switch (typeObj)
            {
                case TypeMovementObject.Player:
                    stoppingDistance = _mainParameters.Settings.MinStoppingDistance;
                    target = _mainParameters.TransformPlayer.position;
                    break;
                case TypeMovementObject.StartPosition:
                    target = _mainParameters.StartPoint;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeObj), typeObj, null);
            }

            _mainParameters.Agent.stoppingDistance = stoppingDistance;
            _mainParameters.Agent.SetDestination(target);
        }

        public override void Attack()
        {
            if (_mainParameters.Timer.IsLaunched == false)
            {
                if (_mainParameters.DistanceFromPlayerToEnemy <= _mainParameters.Settings.MaxAttackDistance)
                {
                    BasicParameters.CreatorPlayerSound.Create(BasicParameters.AttackPlayer);
                    BasicParameters.SelectedPlayer.Main.Health.DealDamage(_mainParameters.Settings.DamageWhenAttacking);
                }

                StartCoroutine(_mainParameters.Timer.ToRun(_mainParameters.Settings.DelayAttack));
            }
        }

        public override bool IsGoToIdle()
        {
            return _mainParameters.DistanceFromSelectedPositionToEnemy <
                   _mainParameters.Settings.MinSelectedPointDistance;
        }


        public override void Start()
        {
            SettingUpAnimations = new SettingUpAnimationsEnemyAFK(this);
            _mainParameters = GetComponent<ParametersEnemyAFK>();
            base.Start();
        }
    }
}