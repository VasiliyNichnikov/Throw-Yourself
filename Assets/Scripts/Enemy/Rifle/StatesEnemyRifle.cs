using Enemy.States;
using UnityEngine;

namespace Enemy.Rifle
{
    public class StatesEnemyRifle : MonoBehaviour, IStatesEnemy
    {
        public StateEnemy Idle => _movementToSelectedPoint;
        public StateEnemy MovementBehindPlayer => _movementBehindPlayer;
        public StateEnemy MovementToSelectedPoint => _movementToSelectedPoint;
        public StateEnemy Attack => _attack;

        private StateMovementBehindPlayer _movementBehindPlayer;
        private StateMovementToSelectedPoint _movementToSelectedPoint;
        private StateAttackRifle _attack;

        public void Init(ParentEnemy enemy, StateMachineEnemy stateMachine)
        {
            _movementBehindPlayer = new StateMovementBehindPlayer(enemy, stateMachine);
            _movementToSelectedPoint = new StateMovementToSelectedPoint(enemy, stateMachine);
            _attack = new StateAttackRifle(enemy, stateMachine);
        }
    }
}