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

        public void Restart()
        {
            _player.Disconnection();
            SceneManager.LoadScene(GetIndexActiveScene());
        }

        public void LoadToNextScene()
        {
            _player.Disconnection();
            int nextScene = GetIndexActiveScene() + 1;
            SceneManager.LoadScene(nextScene <= _maxLevel ? nextScene : _sceneReturn);
        }

        private int GetIndexActiveScene()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}