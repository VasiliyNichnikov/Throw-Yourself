using System;
using DirectionMovement;
using Enemy;
using LifeSlider;
using MovingToAnotherObject;
using PhysicsObjects;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MovementObject), typeof(InteractionArrow))]
    [RequireComponent(typeof(CrashingIntoEnemy), typeof(PlayerBodySwitch), typeof(HealthPlayer))]
    public class ParentPlayer : MonoBehaviour
    {
        public InteractionArrow InteractionArrow => _interactionArrow;
        public bool PlayerInMotion
        {
            get
            {
                if (_movement != null) return _movement.PlayerInMotion;
                throw new Exception($"Script {nameof(MovementObject)} not found");
            }
        }

        private InteractionArrow _interactionArrow;
        private MovementObject _movement;
        private MeshRenderer _renderer;
        private PlayerBodySwitch _bodySwitch;
        private HealthPlayer _health;


        public void Connection(int layer, Material mat)
        {
            gameObject.layer = layer;
            _renderer.material = mat;
            EventMovementObject.EventMove += _movement.Push;
            EventChangerPlayerBody.EventBeamThrow += _bodySwitch.BeamThrow;
            EventChangerPlayerBody.EventChangeBody += _bodySwitch.ChangePlayer;
            EventsLifeSlider.EventTakingDamage += _health.Damage;
        }

        public void Disconnection(int layer, Material mat)
        {
            gameObject.layer = layer;
            _renderer.material = mat;
            EventMovementObject.EventMove -= _movement.Push;
            EventChangerPlayerBody.EventBeamThrow -= _bodySwitch.BeamThrow;
            EventChangerPlayerBody.EventChangeBody -= _bodySwitch.ChangePlayer;
            EventsLifeSlider.EventTakingDamage -= _health.Damage;
            _interactionArrow.Remove();
            _movement.StopCheckingPlayerMovement(true);
            _health.RemoveSlider();
            EventEnemy.LaunchEventResetParameters();
        }

        private void Start()
        {
            _interactionArrow = GetComponent<InteractionArrow>();
            _renderer = GetComponent<MeshRenderer>();
            _movement = GetComponent<MovementObject>();
            _bodySwitch = GetComponent<PlayerBodySwitch>();
            _health = GetComponent<HealthPlayer>();
        }
    }
}