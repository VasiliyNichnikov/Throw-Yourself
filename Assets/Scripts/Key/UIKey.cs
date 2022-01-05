using System;
using UnityEngine;

namespace Key
{
    public class UIKey : MonoBehaviour
    {
        public KeyStatus SelectedKey
        {
            get
            {
                if (_selectedKey != null)
                    return _selectedKey;
                throw new Exception("There is no selected key, since no key is matched");
            }
        }

        [SerializeField] private KeyStatus[] _keys;
        [SerializeField] private GameManager _gameManager;
        private KeyStatus _selectedKey;

        public void CollectKey(Sprite collectedIcon)
        {
            foreach (var key in _keys)
            {
                if (key.IsAssembled == false)
                {
                    key.GetKey(collectedIcon);
                    _selectedKey = key;
                }
            }
        }
    }
}