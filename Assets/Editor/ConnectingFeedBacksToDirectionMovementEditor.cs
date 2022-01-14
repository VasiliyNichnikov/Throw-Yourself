using DirectionMovement.FeedBacks;
using MoreMountains.Feedbacks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ConnectingFeedBacksDirectionMovement))]
    public class ConnectingFeedBacksToDirectionMovementEditor : UnityEditor.Editor
    {
        private ConnectingFeedBacksDirectionMovement _connectingFeedBacks;
        private const float _minLimit = 0.0f;
        private const float _maxLimit = 100.0f;

        private void OnEnable()
        {
            _connectingFeedBacks = target as ConnectingFeedBacksDirectionMovement;
        }

        public override void OnInspectorGUI()
        {
            _connectingFeedBacks.SettingsFirstFeedBack = DrawSettings(_connectingFeedBacks.SettingsFirstFeedBack);
            _connectingFeedBacks.SettingsSecondFeedBack = DrawSettings(_connectingFeedBacks.SettingsSecondFeedBack);
            _connectingFeedBacks.SettingsThirdFeedBack = DrawSettings(_connectingFeedBacks.SettingsThirdFeedBack);

            if (GUI.changed)
            {
                SetObjectDirty(_connectingFeedBacks.gameObject);
            }
        }

        private SettingsFeedBackDirectionMovement DrawSettings(SettingsFeedBackDirectionMovement settings)
        {
            settings.ShowBlock = EditorGUILayout.BeginFoldoutHeaderGroup(settings.ShowBlock, "Block settings feedback");
            if (settings.ShowBlock)
            {
                settings.FeedBack =
                    EditorGUILayout.ObjectField("Feedback", settings.FeedBack, typeof(MMFeedbacks), true) as
                        MMFeedbacks;
                settings.LevelFeedBack.Min = EditorGUILayout.FloatField("Min", settings.LevelFeedBack.Min);
                settings.LevelFeedBack.Max = EditorGUILayout.FloatField("Max", settings.LevelFeedBack.Max);
                EditorGUILayout.MinMaxSlider("Min and max values", ref settings.LevelFeedBack.Min,ref settings.LevelFeedBack.Max, _minLimit, _maxLimit);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            return settings;
        }

        private void SetObjectDirty(GameObject obj)
        {
            EditorUtility.SetDirty(obj);
            EditorSceneManager.MarkSceneDirty(obj.scene);
        }
    }
}