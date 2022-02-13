using DirectionMovement.FeedBacks;
using MoreMountains.Feedbacks;
using Player.FeedBacks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ThreeLevelFeedBack))]
    public class ThreeLevelFeedBackEditor : UnityEditor.Editor
    {
        private ThreeLevelFeedBack _threeLevelFeedBacks;
        private const float _minLimit = 0.0f;
        private const float _maxLimit = 100.0f;

        private void OnEnable()
        {
            _threeLevelFeedBacks = target as ThreeLevelFeedBack;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _threeLevelFeedBacks.SettingsFirstFeedBack = DrawSettings(_threeLevelFeedBacks.SettingsFirstFeedBack);
            _threeLevelFeedBacks.SettingsSecondFeedBack = DrawSettings(_threeLevelFeedBacks.SettingsSecondFeedBack);
            _threeLevelFeedBacks.SettingsThirdFeedBack = DrawSettings(_threeLevelFeedBacks.SettingsThirdFeedBack);
            if (GUI.changed)
            {
                SetObjectDirty(_threeLevelFeedBacks.gameObject);
                PrefabUtility.RecordPrefabInstancePropertyModifications(this);
            }
            serializedObject.ApplyModifiedProperties();
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
            EditorUtility.SetDirty(_threeLevelFeedBacks);
            EditorSceneManager.MarkSceneDirty(obj.scene);
        }
    }
}