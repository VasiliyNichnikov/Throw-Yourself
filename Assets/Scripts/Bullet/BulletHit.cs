using LifeSlider;
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
        
        private int _layerPlayer; // TODO нужно чтобы слой можно было выбрать в unity
        private float _damage;

        private void Start()
        {
            _layerPlayer = LayerMask.NameToLayer("Player");
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _layerPlayer)
            {
                EventsLifeSlider.LauncherEventTakingDamage(_damage);
            }

            Destroy(this.gameObject);
        }
    }
}