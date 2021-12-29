using Enemy;
using Particulars;
using PhysicsObjects;
using Sound;
using UnityEngine;

namespace Player
{
    public class CrashingIntoEnemy : MonoBehaviour
    {
        [SerializeField, Range(0, 50)] private float _minRelativeVelocityForKilling;
        [SerializeField] private ActivatorParticle _activatorParticle;
        [SerializeField] private AudioClip _hitEnemy;
        [SerializeField] private AudioClip _hitWall;
        private CreatorPlayerSound _creatorPlayerSound;
        private MovementObject _movement;
        private CreatorOfParticulars _creatorOfParticulars;
        private int _layerCustom; // TODO сделать выбор слоя через Unity
        private Timer _timer;

        private void Start()
        {
            _layerCustom = LayerMask.NameToLayer("Custom");
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