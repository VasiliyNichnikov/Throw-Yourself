using Level;
using LifeSlider;
using Player.FeedBacks;
using UnityEngine;

namespace Player
{
    public class HealthPlayer : MonoBehaviour
    {
        private float _nowHp;
        private TransitionBetweenLevels _transitionBetween;
        private Transform _thisTransform;
        private CreatorLifeSlider _lifeSlider;
        private ConnectingFeedBacks _feedBacks;
        private bool _isDeath; // TODO костыль, чтобы звук не дублировался

        private void Start()
        {
            _nowHp = 100f;
            _feedBacks = GetComponent<ConnectingFeedBacks>();
            _thisTransform = transform;
            _transitionBetween = FindObjectOfType<TransitionBetweenLevels>();
            _lifeSlider = FindObjectOfType<CreatorLifeSlider>();
        }


        public void DealDamage(float qty)
        {
            _nowHp -= qty;
            _lifeSlider.ActivateLifeSlider(_thisTransform, _nowHp, qty, true);
            _feedBacks.PlayDamagePlayerFeedBack();
            if (_nowHp <= 0 && _isDeath == false)
            {
                _feedBacks.PlayPlayerDeath();
                _isDeath = true;
                _transitionBetween.Restart();
            }
        }

        public void RemoveSlider()
        {
            _lifeSlider.Remove();
        }
    }
}