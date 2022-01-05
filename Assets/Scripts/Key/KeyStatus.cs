using UnityEngine;
using UnityEngine.UI;

namespace Key
{
    public class KeyStatus : MonoBehaviour
    {
        public RectTransform Rect { get; private set; }
        public bool IsAssembled { get; private set; }
        private Image _image;
        private Sprite _collectedIcon;

        public void GetKey(Sprite newSprite)
        {
            _collectedIcon = newSprite;
            IsAssembled = true;
        }

        public void ChangeSprite()
        {
            _image.sprite = _collectedIcon;
        }

        private void Start()
        {
            Rect = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
        }
    }
}