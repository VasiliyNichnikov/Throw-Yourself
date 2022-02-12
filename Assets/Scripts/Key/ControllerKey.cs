using System;
using UnityEngine;

namespace Key
{
    public class ControllerKey : MonoBehaviour
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
        private KeyStatus _selectedKey;
        
        public bool LevelPassed()
        {
            int numberOfKeysCollected = 0;
            foreach (var key in _keys)
            {
                if (key.IsAssembled)
                    numberOfKeysCollected++;
            }

            return numberOfKeysCollected == _keys.Length;
        }
        
        public void CollectKey(Sprite collectedIcon)
        {
            foreach (var key in _keys)
            {
                if (key.IsAssembled == false)
                {
                    key.GetKey(collectedIcon);
                    _selectedKey = key;
                    return;
                }
            }
        }
    }
}