using System;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace DirectionMovement.FeedBacks
{
    [Serializable]
    public class SettingsFeedBackDirectionMovement
    {
        public bool ShowBlock;
        public MinMaxValues LevelFeedBack => _levelFeedBack;
        public MMFeedbacks FeedBack
        {
            get => _feedBack;
            set
            {
#if UNITY_EDITOR
                if (value != null)
                    _feedBack = value;
#endif
            }
        }

        [SerializeField] private MMFeedbacks _feedBack;
        [SerializeField] private MinMaxValues _levelFeedBack;

        public bool CheckIfValueInZone(float value)
        {
            return value > _levelFeedBack.MinClamp01 && value <= _levelFeedBack.MaxClamp01;
        }

        public void PlayFeedBack()
        {
            if(_feedBack == null)
                return;
            _feedBack.PlayFeedbacks();
        }
        
    }
}