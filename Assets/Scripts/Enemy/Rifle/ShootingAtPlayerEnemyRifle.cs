using System;
using Bullet;
using Player;
using UnityEngine;

namespace Enemy.Rifle
{
    public class ShootingAtPlayerEnemyRifle : MonoBehaviour
    {
        private Transform _parentBulletTransform;

        private void Awake()
        {
            _parentBulletTransform = transform;
            ParentBullet parent = FindObjectOfType<ParentBullet>();
            if (parent == null)
                throw new Exception($"Component {nameof(ParentPlayer)} not found");
            _parentBulletTransform = parent.transform;
        }

        public void Shoot(GameObject prefabBullet, Vector3 position, Vector3 direction, float damage)
        {
            BulletFlight newBullet =
                Instantiate(prefabBullet, position, Quaternion.identity).GetComponent<BulletFlight>();
            newBullet.transform.SetParent(_parentBulletTransform);
            newBullet.ToRun(direction, damage);
        }
    }
}