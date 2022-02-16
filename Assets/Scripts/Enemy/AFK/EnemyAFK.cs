using System;
using UnityEngine;

namespace Enemy.AFK
{
    public class EnemyAFK : ParentEnemy
    {
        private StatesEnemyAFK _states;
        private ParametersEnemyAFK _settings;

        public override void Move(TypeMovementObject typeObj)
        {
            float stoppingDistance = 0;
            Vector3 target;
            switch (typeObj)
            {
                case TypeMovementObject.Player:
                    stoppingDistance = _settings.MinStoppingDistance;
                    target = _settings.TransformPlayer.position;
                    break;
                case TypeMovementObject.StartPosition:
                    target = StartPoint;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeObj), typeObj, null);
            }

            Agent.stoppingDistance = stoppingDistance;
            Agent.SetDestination(target);
        }

        public override void Attack()
        {
            if (Timer.IsLaunched == false)
            {
                if (DistanceFromPlayerToEnemy <= _settings.MaxAttackDistance)
                {
                    BasicSettings.CreatorPlayerSound.Create(BasicSettings.AttackSound);
                    BasicSettings.SelectedPlayer.Main.Health.DealDamage(_settings.DamageWhenAttacking);
                }

                StartCoroutine(Timer.ToRun(_settings.DelayAttack));
            }
        }

        public override bool IsGoToIdle()
        {
            return DistanceFromSelectedPositionToEnemy < _settings.MinSelectedPointDistance;
        }


        public override void Start()
        {
            SettingUpAnimations = new SettingUpAnimationsEnemyAFK(this);
            _settings = BasicSettings as ParametersEnemyAFK;
            base.Start();
        }
    }
}