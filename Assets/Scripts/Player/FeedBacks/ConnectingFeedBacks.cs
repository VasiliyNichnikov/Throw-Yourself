using MoreMountains.Feedbacks;
using UnityEngine;

namespace Player.FeedBacks
{
    public class ConnectingFeedBacks : MonoBehaviour
    {
        [SerializeField, Header("Действие при толчке игрока (Уровень первый)")]
        private MMFeedbacks _throwingPlayerFirstFeedBack;

        [SerializeField, Header("Действие при толчке игрока (Уровень второй)")]
        private MMFeedbacks _throwingPlayerSecondFeedBack;

        [SerializeField, Header("Действие при толчке игрока (Уровень третий)")]
        private MMFeedbacks _throwingPlayerThirdFeedBack;

        [SerializeField, Header("Действие при уничтожение игрока")]
        private MMFeedbacks _deathPlayerFeedBack;

        [SerializeField, Header("Действие при попадание в игрока")]
        private MMFeedbacks _damagePlayerFeedBack;

        private ParentPlayer _player;

        public void PlayThrowingPlayer(float value)
        {
            if (value >= _player.Parameters.MinimumForceTensionArrow &&
                value < _player.Parameters.TensionLevelForFirstFeedBackArrow)
            {
                print("Throwing feedBack level 1");
                _throwingPlayerFirstFeedBack.PlayFeedbacks();
            }
            else if (value >= _player.Parameters.TensionLevelForFirstFeedBackArrow &&
                     value < _player.Parameters.TensionLevelForSecondFeedBackArrow)
            {
                print("Throwing feedBack level 2");
                _throwingPlayerSecondFeedBack.PlayFeedbacks();
            }
            else if (value >= _player.Parameters.TensionLevelForSecondFeedBackArrow &&
                     value <= _player.Parameters.TensionLevelForThirdFeedBackArrow)
            {
                print("Throwing feedBack level 3");
                _throwingPlayerThirdFeedBack.PlayFeedbacks();
            }
        }

        public void PlayPlayerDeath()
        {
            _deathPlayerFeedBack.PlayFeedbacks();
        }

        public void PlayDamagePlayerFeedBack()
        {
            _damagePlayerFeedBack.PlayFeedbacks();
        }

        private void Start()
        {
            _player = GetComponent<ParentPlayer>();
        }
    }
}