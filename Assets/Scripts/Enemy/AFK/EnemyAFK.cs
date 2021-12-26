using System;
using LifeSlider;
using UnityEngine;

namespace Enemy.AFK
{
    public class EnemyAFK : ParentEnemy
    {
        private StatesEnemyAFK _states;
        private ParametersEnemyAFK _parameters;

        public override void Move(TypeMovementObject typeObj)
        {
            float stoppingDistance = 0;
            Vector3 target;
            switch (typeObj)
            {
                case TypeMovementObject.Player:
                    stoppingDistance = _parameters.MinStoppingDistance;
                    target = _parameters.TransformPlayer.position;
                    break;
                case TypeMovementObject.StartPosition:
                    target = _parameters.StartPoint;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeObj), typeObj, null);
            }

            _parameters.Agent.stoppingDistance = stoppingDistance;
            _parameters.Agent.SetDestination(target);
        }

        public override void Attack()
        {
            if (_parameters.Timer.IsLaunched == false)
            {
                if (_parameters.DistanceFromPlayerToEnemy <= _parameters.MinAttackDistance)
                {
                    // BasicParameters.SelectedPlayer.Player.PlayerTakingDamage.LauncherAnimationDamage();
                    BasicParameters.CreatorPlayerSound.Create(BasicParameters.AttackPlayer);
                    BasicParameters.SelectedPlayer.Main.Health.DealDamage(_parameters.DamagePlayerWhenAttacking);
                }

                StartCoroutine(_parameters.Timer.ToRun(_parameters.DelayAttack));
            }
        }

        public override bool IsGoToIdle()
        {
            return _parameters.DistanceFromSelectedPositionToEnemy < _parameters.MinDistanceToSelectedPoint;
        }
        

        public override void Start()
        {
            SettingUpAnimations = new SettingUpAnimationsEnemyAFK(this);
            _parameters = GetComponent<ParametersEnemyAFK>();
            base.Start();
        }
    }
}