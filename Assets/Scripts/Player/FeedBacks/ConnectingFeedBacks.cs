using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.FeedBacks
{
    public class ConnectingFeedBacks : MonoBehaviour
    {
        [FormerlySerializedAs("_attackEnemyFeedBack")] [SerializeField, Header("Действие при бросание игрока")]
        private MMFeedbacks _throwingPlayerFeedBack;

        [SerializeField, Header("Действие при уничтожение игрока")]
        private MMFeedbacks _deathPlayerFeedBack;

        [SerializeField, Header("Действие при попадание в игрока")]
        private MMFeedbacks _damagePlayerFeedBack;

        public void PlayThrowingPlayer()
        {
            _throwingPlayerFeedBack.PlayFeedbacks();
        }

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