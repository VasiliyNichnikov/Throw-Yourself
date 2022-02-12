using Analytics;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(PlayerSessionAnalytics))]
    public class PlayerSessionAnalyticsEditor : UnityEditor.Editor
    {
        private PlayerSessionAnalytics _playerSession;
        
        public void OnEnable()
        {
            _playerSession = target as PlayerSessionAnalytics;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Reset PlayerPrefs parameters"))
            {
                _playerSession.ResetPlayerPrefsParameters();
            }
        }
    }
}