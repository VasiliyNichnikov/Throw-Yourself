using Bullet;
using UnityEngine;

namespace Enemy.Rifle
{
    public class ShootingAtPlayerEnemyRifle : MonoBehaviour
    {
        [SerializeField] private Transform _parentBullet;
        [SerializeField] private GameObject _prefabBullet;
            
        public void Shoot(Vector3 position, Vector3 direction, float damage)
        {
            BulletFlight newBullet = Instantiate(_prefabBullet, position, Quaternion.identity).GetComponent<BulletFlight>();
            newBullet.transform.SetParent(_parentBullet);
            newBullet.ToRun(direction, damage);
        }
    }
}