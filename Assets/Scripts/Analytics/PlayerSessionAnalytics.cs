using Level;
using UnityEngine;

namespace Analytics
{
    public class PlayerSessionAnalytics : MonoBehaviour
    {
        // Ключи для PlayerPrefs
        private const string _levelNumberKey = "levelNumber";
        private const string _levelLoopKey = "levelLoop";
        private const string _levelCountKey = "levelCount";
        // Параметры по умолчанию
        private const int _levelRandom = 0;
        private const string _levelType = "normal";
        private const string _gameMode = "classic";
        private LevelInformation _level;
        // Параметр, кол-во секунд пройшедшее с запуска уровня
        private float _startTimeLevel;
        // Данный уровень является первым по прохождению игроком
        private static bool _firstPassageOfLevel;


        public void SendStartStatistics()
        {
            print("--------------Send START statistics--------------");
            print($"Level number: {WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey)}");
            print($"Level name: {_level.Name}");
            print($"Level count: {WorkingWithPlayerPrefs.GetDataInt(_levelCountKey)}");
            print($"Level diff: {_level.Difficulty}");
            print($"Level loop: {WorkingWithPlayerPrefs.GetDataInt(_levelLoopKey)}");
            print($"Level random: {_levelRandom}");
            print($"Level type: {_levelType}");
            print($"Game mode: {_gameMode}");
            _startTimeLevel = Time.time;
            print("-------------------------------------------------");
        }

        public void SendFinishStatistics(LevelCompletionStates completionState)
        {
            print("--------------Send FINISH statistics--------------");
            print($"Level number: {WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey)}");
            print($"Level name: {_level.Name}");
            print($"Level count: {WorkingWithPlayerPrefs.GetDataInt(_levelCountKey)}");
            print($"Level diff: {_level.Difficulty}");
            print($"Level loop: {WorkingWithPlayerPrefs.GetDataInt(_levelLoopKey)}");
            print($"Level random: {_levelRandom}");
            print($"Level type: {_levelType}");
            print($"Game mode: {_gameMode}");
            print($"Time - {Time.time - _startTimeLevel} seconds");
            if (completionState == LevelCompletionStates.Win)
            {
                print("Result: win");
                print("Progress: 100");
            }
            else
            {
                print("Result: lose");
                print("Progress: 0");
            }
            print("-------------------------------------------------");
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
            WorkingWithPlayerPrefs.SaveData(_levelNumberKey, levelNumber);
            WorkingWithPlayerPrefs.SaveData(_levelLoopKey, levelLoop);
            WorkingWithPlayerPrefs.SaveData(_levelCountKey, levelCount);
        }
        
        private void Start()
        {
            _level = GetComponent<LevelInformation>();
            if (_firstPassageOfLevel == false)
            {
                SendStartStatistics();
                _firstPassageOfLevel = true;
            }
        }
        
    }
}