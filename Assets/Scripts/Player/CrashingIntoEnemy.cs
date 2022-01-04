using Enemy;
using Particulars;
using PhysicsObjects;
using Player.FeedBacks;
using Sound;
using UnityEngine;

namespace Player
{
    public class CrashingIntoEnemy : MonoBehaviour
    {
        public float MinRelativeVelocityForKilling
        {
            set
            {
                if (value >= 0) _minRelativeVelocityForKilling = value;
            }
        }

        public ActivatorParticle ActivatorParticle
        {
            set
            {
                if (value != null) _activatorParticle = value;
            }
        }

        public AudioClip HitEnemy
        {
            set
            {
                if (value != null) _hitEnemy = value;
            }
        }

        public AudioClip HitWall
        {
            set
            {
                if (value != null) _hitWall = value;
            }
        }

        private float _minRelativeVelocityForKilling;
        private ActivatorParticle _activatorParticle;
        private ConnectingFeedBacks _feedBacks;
        
        private AudioClip _hitEnemy;
        private AudioClip _hitWall;

        private CreatorOfParticulars _creatorOfParticulars;
        private CreatorPlayerSound _creatorPlayerSound;
        private MovementObject _movement;

        private int _layerCustom; // TODO сделать выбор слоя через Unity
        private Timer _timer;

        private void Start()
        {
            _layerCustom = LayerMask.NameToLayer("Custom");
            _feedBacks = GetComponent<ConnectingFeedBacks>();
            _movement = GetComponent<MovementObject>();
            _creatorOfParticulars = FindObjectOfType<CreatorOfParticulars>();
            _creatorPlayerSound = FindObjectOfType<CreatorPlayerSound>();
            _timer = new Timer();
        }

        private void OnCollisionEnter(Collision collision)
        {
            ParentEnemy enemy = collision.collider.GetComponent<ParentEnemy>();

            if (enemy != null && collision.relativeVelocity.magnitude >= _minRelativeVelocityForKilling &&
                _movement.PlayerInMotion)
            {
                _creatorOfParticulars.Create(_activatorParticle, collision.GetContact(0).point);
                _creatorPlayerSound.Create(_hitEnemy);
                _feedBacks.PlayEnemyAttack();
                enemy.Death();
            }
            else if (collision.gameObject.layer == _layerCustom && _timer.IsLaunched == false)
            {
                _creatorPlayerSound.Create(_hitWall);
                StartCoroutine(_timer.ToRun(0.6f));
            }
        }
    }
}