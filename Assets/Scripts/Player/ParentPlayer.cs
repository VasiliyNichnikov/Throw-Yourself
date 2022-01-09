using System;
using DirectionMovement;
using Events;
using MovingToAnotherObject;
using PhysicsObjects;
using Player.FeedBacks;
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
        public MeshRenderer Renderer { get; private set; }
        public ConnectingFeedBacks FeedBacks { get; private set; }
        public bool RelocationIsAllowed => _parameters.RelocationIsAllowed;

        [SerializeField, Header("Параметры игрока")]
        private ParametersPlayer _parameters;

        private CrashingIntoEnemy _crashingIntoEnemy;


        public bool PlayerInMotion
        {
            get
            {
                if (Engine != null) return Engine.PlayerInMotion;
                throw new Exception($"Script {nameof(MovementObject)} not found");
            }
        }

        private EnemyEvents _enemyEvents;


        public void Connection(int layer, Material mat)
        {
            gameObject.layer = layer;
            Renderer.material = mat;
        }

        public void Disconnection(int layer, Material mat)
        {
            gameObject.layer = layer;
            Renderer.material = mat;
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
            FeedBacks = GetComponent<ConnectingFeedBacks>();
            _crashingIntoEnemy = GetComponent<CrashingIntoEnemy>();

            Renderer = GetComponent<MeshRenderer>();
            _enemyEvents = FindObjectOfType<EventKeeper>().EnemyEvents;
            InitParameters();
        }

        private void InitParameters()
        {
            if (_parameters == null)
                throw new Exception("Error, there is no parameter!");
            Engine.Speed = _parameters.ForceOfPush;
            BodySwitch.HeightRay = _parameters.HeightRay;
            _crashingIntoEnemy.MinRelativeVelocityForKilling = _parameters.MinRelativeVelocityForKilling;
            _crashingIntoEnemy.ActivatorParticle = _parameters.ActivatorParticle;
            _crashingIntoEnemy.HitEnemy = _parameters.HitEnemy;
            _crashingIntoEnemy.HitWall = _parameters.HitWall;
        }
    }
}