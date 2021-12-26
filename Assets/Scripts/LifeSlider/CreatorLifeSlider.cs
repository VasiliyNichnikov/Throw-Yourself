using System.Collections;
using UnityEngine;

namespace LifeSlider
{
    public class CreatorLifeSlider : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabLifeSlider;

        [SerializeField, Header("Ожидание завершения атаки"), Range(0, 10)]
        private float _waitingTimeAttackComplete;

        [SerializeField, Header("Высота слайдера")]
        private float _height;

        [SerializeField, Header("Поворот созданного слайдера")]
        private Vector3 _rotation;

        private Transform _createdLifeSlider;

        private Transform _thisTransform;
        private IEnumerator _runningTimer;

        public void ActivateLifeSlider(Transform player, float nowHp, float damage, bool changeAngleY = false)
        {
            if (_createdLifeSlider == null)
            {
                Create(player.position, changeAngleY);
            }

            if (_runningTimer != null)
                StopCoroutine(_runningTimer);

            LifeSliderMovementBehindPlayer movementBehindPlayer =
                _createdLifeSlider.GetComponent<LifeSliderMovementBehindPlayer>();
            AnimationChangingLife changingLife = _createdLifeSlider.GetComponent<AnimationChangingLife>();

            if (movementBehindPlayer != null)
                movementBehindPlayer.ToFollow(player, _height);
            if (changingLife != null)
                changingLife.StartingAnimation(nowHp, nowHp - damage);

            _runningTimer = Timer(_waitingTimeAttackComplete);
            StartCoroutine(_runningTimer);
        }

        public void Remove()
        {
            if (_createdLifeSlider != null)
                Destroy(_createdLifeSlider.gameObject);
        }

        private void Create(Vector3 position, bool changeAngleY)
        {
            if (changeAngleY)
            {
                position.y = _height;
            }

            _createdLifeSlider = Instantiate(_prefabLifeSlider, position, Quaternion.Euler(_rotation)).transform;
            _createdLifeSlider.SetParent(_thisTransform);
        }

        private IEnumerator Timer(float delay)
        {
            yield return new WaitForSeconds(delay);
            Remove();
        }

        private void Start()
        {
            _thisTransform = transform;
        }
    }
}