using Level;
using LifeSlider;
using UnityEngine;

namespace Player
{
    public class HealthPlayer : MonoBehaviour
    {
        private float _nowHp;
        private TransitionBetweenLevels _transitionBetween;
        private Transform _thisTransform;
        private CreatorLifeSlider _lifeSlider;

        private void Start()
        {
            _nowHp = 100f;
            _thisTransform = transform;
            _transitionBetween = FindObjectOfType<TransitionBetweenLevels>();
            _lifeSlider = FindObjectOfType<CreatorLifeSlider>();
        }


        public void DealDamage(float qty)
        {
            _nowHp -= qty;
            _lifeSlider.ActivateLifeSlider(_thisTransform, _nowHp, qty, true);
            if (_nowHp <= 0)
            {
                _transitionBetween.Restart();
            }
        }

        public void RemoveSlider()
        {
            _lifeSlider.Remove();
        }
    }
}