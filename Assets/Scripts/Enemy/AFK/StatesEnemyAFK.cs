using Enemy.States;
using UnityEngine;

namespace Enemy.AFK
{
    public class StatesEnemyAFK : MonoBehaviour, IStatesEnemy
    {
        public StateEnemy Idle => _idle;
        public StateEnemy MovementBehindPlayer => _movementBehindPlayer;
        public StateEnemy MovementToSelectedPoint => _movementToStartingPoint;
        public StateEnemy Attack => _attack;

        private StateIdle _idle;
        private StateMovementBehindPlayer _movementBehindPlayer;
        private StateMovementToStartingPoint _movementToStartingPoint;
        private StateAttackCloseCombat _attack;

        public void Init(ParentEnemy enemy, StateMachineEnemy stateMachine)
        {
            _idle = new StateIdle(enemy, stateMachine);
            _movementBehindPlayer = new StateMovementBehindPlayer(enemy, stateMachine);
            _movementToStartingPoint = new StateMovementToStartingPoint(enemy, stateMachine);
            _attack = new StateAttackCloseCombat(enemy, stateMachine);
        }
    }
}