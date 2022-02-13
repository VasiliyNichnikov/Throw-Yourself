using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Analytics
{
    public class PlayerSessionAnalytics : MonoBehaviour
    {
        // Настройки отправки данных
        [SerializeField, Header("Вывод в консоль")]
        private bool _isOutputToConsole;

        [SerializeField, Header("Отправка аналитики на сервер (отправка будет доступна только на самом телефоне)")]
        private bool _isSendingToServer;

        // Сохранение последнего пройденного уровня
        private int _lastCompletedLevel;

        // Ключи для PlayerPrefs
        private const string _levelNumberKey = "levelNumber";
        private const string _levelLoopKey = "levelLoop";
        private const string _levelCountKey = "levelCount";
        private const string _lastCompletedLevelKey = "lastCompletedLevel";

        // Параметры по умолчанию
        private const int _levelRandom = 0;
        private const string _levelType = "normal";
        private const string _gameMode = "classic";
        private LevelInformation _level;

        // Параметр, кол-во секунд пройшедшее с запуска уровня
        private float _startTimeLevel;

        // Объект яндекс аналитики
        private IYandexAppMetrica _metrica;

        public void SendStartStatistics()
        {
            int levelNumber = WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey);
            string levelName = _level.Name;
            int levelCount = WorkingWithPlayerPrefs.GetDataInt(_levelCountKey);
            string levelDiff = _level.Difficulty.ToString().ToLower();
            int levelLoop = WorkingWithPlayerPrefs.GetDataInt(_levelLoopKey);
            if (_isOutputToConsole)
            {
                print("--------------Send START statistics--------------");
                print($"Level number: {levelNumber}");
                print($"Level name: {levelName}");
                print($"Level count: {levelCount}");
                print($"Level diff: {levelDiff}");
                print($"Level loop: {levelLoop}");
                print($"Level random: {_levelRandom}");
                print($"Level type: {_levelType}");
                print($"Game mode: {_gameMode}");
                print("-------------------------------------------------");
            }

            if (_isSendingToServer)
            {
                _metrica.ReportEvent("level_start", new Dictionary<string, object>()
                {
                    {"level_number", WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey)},
                    {"level_name", levelName},
                    {"level_count", levelCount},
                    {"level_diff", levelDiff},
                    {"level_loop", levelLoop},
                    {"level_random", _levelRandom},
                    {"level_type", _levelType},
                    {"game_mode", _gameMode}
                });
                _metrica.SendEventsBuffer();
            }

            _startTimeLevel = Time.time;
        }

        public void SendFinishStatistics(LevelCompletionStates completionState)
        {
            int levelNumber = WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey);
            string levelName = _level.Name;
            int levelCount = WorkingWithPlayerPrefs.GetDataInt(_levelCountKey);
            string levelDiff = _level.Difficulty.ToString().ToLower();
            int levelLoop = WorkingWithPlayerPrefs.GetDataInt(_levelLoopKey);
            string result;
            int progress;
            int passageTime = Mathf.RoundToInt(Time.time - _startTimeLevel);
            if (completionState == LevelCompletionStates.Win)
            {
                result = "win";
                progress = 100;
            }
            else
            {
                result = "lose";
                progress = 0;
            }

            SaveSelectedLevel();
            if (_isOutputToConsole)
            {
                print("--------------Send FINISH statistics--------------");
                print($"Level number: {levelNumber}");
                print($"Level name: {levelName}");
                print($"Level count: {levelCount}");
                print($"Level diff: {levelDiff}");
                print($"Level loop: {levelLoop}");
                print($"Level random: {_levelRandom}");
                print($"Level type: {_levelType}");
                print($"Game mode: {_gameMode}");
                print($"Result: {result}");
                print($"Progress: {progress}");
                print($"Time: {passageTime} seconds");
                print("-------------------------------------------------");
            }

            if (_isSendingToServer)
            {
                _metrica.ReportEvent("level_start", new Dictionary<string, object>()
                {
                    {"level_number", WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey)},
                    {"level_name", levelName},
                    {"level_count", levelCount},
                    {"level_diff", levelDiff},
                    {"level_loop", levelLoop},
                    {"level_random", _levelRandom},
                    {"level_type", _levelType},
                    {"game_mode", _gameMode},
                    {"result", result},
                    {"time", passageTime},
                    {"progress", progress}
                });
                _metrica.SendEventsBuffer();
            }
        }

        public void UpgradeLevelNumber()
        {
            int levelNumber = WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey);
            levelNumber++;
            WorkingWithPlayerPrefs.SaveData(_levelNumberKey, levelNumber);
        }

        public void CheckLevelLoop(int maxLevel)
        {
            if (_level.Number == maxLevel)
            {
                int levelLoop = WorkingWithPlayerPrefs.GetDataInt(_levelLoopKey);
                levelLoop++;
                WorkingWithPlayerPrefs.SaveData(_levelLoopKey, levelLoop);
            }
        }

        public void UpgradeLevelCount()
        {
            int levelCount = WorkingWithPlayerPrefs.GetDataInt(_levelCountKey);
            levelCount++;
            WorkingWithPlayerPrefs.SaveData(_levelCountKey, levelCount);
        }

        public void ResetPlayerPrefsParameters()
        {
            int levelNumber = 1;
            int levelLoop = 0;
            int levelCount = 1;
            int lastCompletedLevel = 0;
            WorkingWithPlayerPrefs.SaveData(_levelNumberKey, levelNumber);
            WorkingWithPlayerPrefs.SaveData(_levelLoopKey, levelLoop);
            WorkingWithPlayerPrefs.SaveData(_levelCountKey, levelCount);
            WorkingWithPlayerPrefs.SaveData(_lastCompletedLevelKey, lastCompletedLevel);
        }

        private void Start()
        {
            _level = GetComponent<LevelInformation>();
            CheckSavedLevel();
            if (_isSendingToServer)
                Debug.LogWarning("Отправка аналитики на сервер включена");
            _metrica = AppMetrica.Instance;
            SendStartStatistics();
        }

        private void CheckSavedLevel()
        {
            _lastCompletedLevel = WorkingWithPlayerPrefs.GetDataInt(_lastCompletedLevelKey);
            if (_lastCompletedLevel != _level.Number - 1)
            {
                SceneManager.LoadScene(_lastCompletedLevel);
            }
        }

        private void SaveSelectedLevel()
        {
            _lastCompletedLevel++;
            WorkingWithPlayerPrefs.SaveData(_lastCompletedLevelKey, _lastCompletedLevel);
        }
    }
}