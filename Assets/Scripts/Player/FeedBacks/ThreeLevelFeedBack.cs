using DirectionMovement.FeedBacks;
using UnityEngine;

namespace Player.FeedBacks
{
    public class ThreeLevelFeedBack : MonoBehaviour
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
                _settingsFirstFeedBack.PlayFeedBack();
            }
            else if (_settingsSecondFeedBack.CheckIfValueInZone(value))
            {
                _settingsSecondFeedBack.PlayFeedBack();
            }
            else if (_settingsThirdFeedBack.CheckIfValueInZone(value))
            {
                _settingsThirdFeedBack.PlayFeedBack();
            }
        }
    }
}