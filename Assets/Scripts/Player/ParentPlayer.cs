using System;
using DirectionMovement;
using Events;
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
        public MovementObject Engine { get; private set; }
        public HealthPlayer Health { get; private set; }
        public CrashingIntoEnemy CrashingIntoEnemy { get; private set; }

        [SerializeField] private ParametersPlayer _parameters;

        public bool PlayerInMotion
        {
            get
            {
                if (Engine != null) return Engine.PlayerInMotion;
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
            Engine.StopCheckingPlayerMovement(true);
            Health.RemoveSlider();
            _enemyEvents.ResetIsNoticesPlayer.Invoke();
        }

        private void Start()
        {
            InteractionArrow = GetComponent<InteractionArrow>();
            Engine = GetComponent<MovementObject>();
            BodySwitch = GetComponent<BodySwitchPlayer>();
            Health = GetComponent<HealthPlayer>();
            CrashingIntoEnemy = GetComponent<CrashingIntoEnemy>();

            _renderer = GetComponent<MeshRenderer>();
            _enemyEvents = FindObjectOfType<EventKeeper>().EnemyEvents;
            InitParameters();
        }

        private void InitParameters()
        {
            if (_parameters == null)
                throw new Exception("Error, there is no parameter!");
            Engine.Speed = _parameters.ForceOfPush;
            BodySwitch.HeightRay = _parameters.HeightRay;
            CrashingIntoEnemy.MinRelativeVelocityForKilling = _parameters.MinRelativeVelocityForKilling;
            CrashingIntoEnemy.ActivatorParticle = _parameters.ActivatorParticle;
            CrashingIntoEnemy.HitEnemy = _parameters.HitEnemy;
            CrashingIntoEnemy.HitWall = _parameters.HitWall;
        }
    }
}