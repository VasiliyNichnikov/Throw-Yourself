using System;
using UnityEngine;
using UnityEngine.UI;

namespace Key
{
    public class UIKey : MonoBehaviour
    {
        [SerializeField] private Image[] _icons;
        private int _index;
        private CreatorKey _creator;

        private void OnEnable()
        {
            EventsKey.EventAddKey += AddKey;
        }

        private void OnDisable()
        {
            EventsKey.EventAddKey -= AddKey;
        }

        private void Start()
        {
            _index = 0;
            _creator = FindObjectOfType<CreatorKey>();
        }

        private void AddKey()
        {
            if (_index < _icons.Length)
                _icons[_index].sprite = _creator.KeyIsAssembled;
            _index++;
        }
    }
}