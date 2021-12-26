using UnityEngine;

namespace Key
{
    public class CreatorKey : MonoBehaviour
    {
        public Sprite KeyIsAssembled => _keyIsAssembled;

        [SerializeField, Header("Углы поворота на разные оси")]
        private Vector3 _rotation;

        [SerializeField, Header("На какой высоте будет создан ключ"), Range(0, 20)]
        private float _height;

        [SerializeField] private GameObject _prefabKey;

        [SerializeField, Header("Иконка, ключ собран")]
        private Sprite _keyIsAssembled;

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
        }
    }
}