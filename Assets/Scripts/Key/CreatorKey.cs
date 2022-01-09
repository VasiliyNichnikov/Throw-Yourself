using UnityEngine;

namespace Key
{
    public class CreatorKey : MonoBehaviour
    {
        [SerializeField, Header("Углы поворота на разные оси")]
        private Vector3 _rotation;

        [SerializeField, Header("На какой высоте будет создан ключ"), Range(0, 20)]
        private float _height;

        [SerializeField] private GameObject _prefabKey;

        [SerializeField, Header("Иконка, ключ собран")]
        private Sprite _collectedIcon;

        [SerializeField] private ControllerKey _controllerKey;
        [SerializeField] private MovingKeyToUI _movingKeyToUI;

        private Transform _thisTransform;

        private void Start()
        {
            _thisTransform = transform;
        }

        public void Create(Vector3 position)
        {
            position.y = _height;
            GameObject newKey = Instantiate(_prefabKey, position, Quaternion.Euler(_rotation));
            newKey.transform.SetParent(_thisTransform);

            _controllerKey.CollectKey(_collectedIcon);
            _movingKeyToUI.AnimationRun(newKey.transform, _controllerKey.SelectedKey);
        }
    }
}