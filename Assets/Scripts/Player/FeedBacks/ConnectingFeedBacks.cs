using MoreMountains.Feedbacks;
using UnityEngine;

namespace Player.FeedBacks
{
    public class ConnectingFeedBacks : MonoBehaviour
    {

        [SerializeField, Header("Действие при уничтожение игрока")]
        private MMFeedbacks _deathPlayerFeedBack;

        [SerializeField, Header("Действие при попадание в игрока")]
        private MMFeedbacks _damagePlayerFeedBack;

        [SerializeField, Header("Действие при толчке")]
        private ThreeLevelFeedBack _pushFeedBack;

        public void PlayPlayerDeathFeadBack()
        {
            _deathPlayerFeedBack.PlayFeedbacks();
        }

        public void PlayPushFeedBack(Vector3 direction)
        {
            float value = MyUtils.GetTensionValue(direction);
            _pushFeedBack.LaunchPushFeedBack(value);
        }
        
        public void PlayDamagePlayerFeedBack()
        {
            _damagePlayerFeedBack.PlayFeedbacks();
        }
    }
}