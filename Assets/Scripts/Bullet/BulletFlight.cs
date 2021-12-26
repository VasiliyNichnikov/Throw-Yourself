using System.Collections;
using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(BulletHit))]
    public class BulletFlight : MonoBehaviour
    {
        [SerializeField, Range(0, 10), Header("Скорость движения пули")]
        private float _speed;

        private bool _launched;
        private Transform _thisTransform;
        private BulletHit _hit;


        public void ToRun(Vector3 direction, float damage)
        {
            if (_launched) return;
            _hit.Damage = damage;
            _launched = true;
            StartCoroutine(Fly(direction));
        }

        private IEnumerator Fly(Vector3 direction)
        {
            while (true)
            {
                _thisTransform.Translate(direction * _speed * Time.deltaTime);
                yield return null;
            }
        }

        private void Awake()
        {
            _launched = false;
            _thisTransform = transform;
            _hit = GetComponent<BulletHit>();
        }
    }
}