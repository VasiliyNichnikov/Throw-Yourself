using MoreMountains.Feedbacks;
using UnityEngine;

namespace Interaction
{
    public class LearningSwitch : MonoBehaviour
    {
        [SerializeField, Header("Скольжение пальца по экрана")]
        private MMFeedbacks _fingerFeedBacks;

        [SerializeField, Header("Изменить позицию камеры")]
        private MMFeedbacks _cameraFeedBacks;

        public void LaunchGame()
        {
            _fingerFeedBacks.PlayFeedbacks();
            _cameraFeedBacks.PlayFeedbacks();
        }
    }
}