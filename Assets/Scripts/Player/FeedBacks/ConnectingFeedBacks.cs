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

        public void PlayPlayerDeath()
        {
            _deathPlayerFeedBack.PlayFeedbacks();
        }

        public void PlayDamagePlayerFeedBack()
        {
            _damagePlayerFeedBack.PlayFeedbacks();
        }
    }
}