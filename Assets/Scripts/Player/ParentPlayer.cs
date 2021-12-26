using System;
using DirectionMovement;
using Enemy;
using Events;
using LifeSlider;
using MovingToAnotherObject;
using PhysicsObjects;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MovementObject), typeof(InteractionArrow))]
    [RequireComponent(typeof(CrashingIntoEnemy), typeof(BodySwitchPlayer), typeof(HealthPlayer))]
    public class ParentPlayer : MonoBehaviour
    {
        public InteractionArrow InteractionArrow { get; private set; }
        public BodySwitchPlayer BodySwitch { get; private set; }
        public MovementObject Movement { get; private set; }
        public HealthPlayer Health { get; private set; }

        public bool PlayerInMotion
        {
            get
            {
                if (Movement != null) return Movement.PlayerInMotion;
                throw new Exception($"Script {nameof(MovementObject)} not found");
            }
        }

        private MeshRenderer _renderer;
        private EnemyEvents _enemyEvents;


        public void Connection(int layer, Material mat)
        {
            gameObject.layer = layer;
            _renderer.material = mat;
        }

        public void Disconnection(int layer, Material mat)
        {
            gameObject.layer = layer;
            _renderer.material = mat;
            InteractionArrow.Remove();
            Movement.StopCheckingPlayerMovement(true);
            Health.RemoveSlider();
            _enemyEvents.ResetIsNoticesPlayer.Invoke();
        }

        private void Start()
        {
            InteractionArrow = GetComponent<InteractionArrow>();
            _renderer = GetComponent<MeshRenderer>();
            Movement = GetComponent<MovementObject>();
            BodySwitch = GetComponent<BodySwitchPlayer>();
            Health = GetComponent<HealthPlayer>();
            _enemyEvents = FindObjectOfType<EventKeeper>().EnemyEvents;
        }
    }
}