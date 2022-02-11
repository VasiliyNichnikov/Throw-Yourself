using Analytics;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class TransitionBetweenLevels : MonoBehaviour
    {
        [SerializeField, Range(0, 100), Header("Максимальная сцена в игре")]
        private int _maxLevel;

        [SerializeField, Range(0, 100), Header("Сцена к которой будет возвращение в случе прохождение игры")]
        private int _sceneReturn;

        [SerializeField] private SelectedPlayer _player;
        [SerializeField] private PlayerSessionAnalytics _sessionAnalytics;

        public void Restart()
        {
            _player.Disconnection();
            _sessionAnalytics.UpgradeLevelCount();
            _sessionAnalytics.SendFinishStatistics(LevelCompletionStates.Lose);
            SceneManager.LoadScene(GetIndexActiveScene());
        }

        public void LoadToNextScene()
        {
            _player.Disconnection();
            int nextScene = GetIndexActiveScene() + 1;
            _sessionAnalytics.SendFinishStatistics(LevelCompletionStates.Win);
            SceneManager.LoadScene(nextScene < _maxLevel ? nextScene : _sceneReturn);
            _sessionAnalytics.UpgradeLevelNumber();
            _sessionAnalytics.CheckLevelLoop(_maxLevel);
            _sessionAnalytics.UpgradeLevelCount();
            _sessionAnalytics.SendStartStatistics();
        }

        private int GetIndexActiveScene()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}