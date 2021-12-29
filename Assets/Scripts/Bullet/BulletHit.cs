using System;
using LifeSlider;
using Player;
using UnityEngine;

namespace Bullet
{
    public class BulletHit : MonoBehaviour
    {
        public float Damage
        {
            get => _damage;
            set
            {
                if (value >= 0)
                    _damage = value;
            }
        }

        [SerializeField] private LayerMask _layerPlayer;
        private float _damage;

        private void Start()
        {
            _layerPlayer = LayerMask.NameToLayer("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == MyUtils.GetLayerNumberByMask(_layerPlayer))
            {
                ParentPlayer player = other.GetComponent<ParentPlayer>();
                if (player == null) throw new Exception("The object does not have a main player script");
                player.Health.DealDamage(_damage);
            }

            Destroy(this.gameObject);
        }
    }
}