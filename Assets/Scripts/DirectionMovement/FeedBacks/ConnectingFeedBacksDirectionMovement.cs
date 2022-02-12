using UnityEngine;

namespace DirectionMovement.FeedBacks
{
    public class ConnectingFeedBacksDirectionMovement : MonoBehaviour
    {
#if UNITY_EDITOR
        public SettingsFeedBackDirectionMovement SettingsFirstFeedBack
        {
            get => _settingsFirstFeedBack;
            set
            {
                if (value != null)
                    _settingsFirstFeedBack = value;
            }
        }

        public SettingsFeedBackDirectionMovement SettingsSecondFeedBack
        {
            get => _settingsSecondFeedBack;
            set
            {
                if (value != null)
                    _settingsSecondFeedBack = value;
            }
        }

        public SettingsFeedBackDirectionMovement SettingsThirdFeedBack
        {
            get => _settingsThirdFeedBack;
            set
            {
                if (value != null)
                    _settingsThirdFeedBack = value;
            }
        }
#endif

        [SerializeField] private SettingsFeedBackDirectionMovement _settingsFirstFeedBack;

        [SerializeField] private SettingsFeedBackDirectionMovement _settingsSecondFeedBack;

        [SerializeField] private SettingsFeedBackDirectionMovement _settingsThirdFeedBack;


        public void LaunchPushFeedBack(float value)
        {
            if (_settingsFirstFeedBack.CheckIfValueInZone(value))
            {
                _settingsFirstFeedBack.FeedBack.PlayFeedbacks();
            }
            else if (_settingsSecondFeedBack.CheckIfValueInZone(value))
            {
                _settingsSecondFeedBack.FeedBack.PlayFeedbacks();
            }
            else if (_settingsThirdFeedBack.CheckIfValueInZone(value))
            {
                _settingsThirdFeedBack.FeedBack.PlayFeedbacks();
            }
        }
    }
}