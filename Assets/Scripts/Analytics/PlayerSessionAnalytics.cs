using UnityEngine;

namespace Analytics
{
    public class PlayerSessionAnalytics : MonoBehaviour
    {
        private static int _levelNumber = 1;
        private static int _levelLoop = 0;
        private const int _levelRandom = 0;
        private const string _levelType = "normal";
        private const string _gameMode = "classic";
        private LevelInformation _level;


        public void SendStartStatistics()
        {
            print("--------------Send start statistics--------------");
            print($"Level number: {_levelNumber}");
            print($"Level name: {_level.Name}");
            print($"Level count: -----");
            print($"Level diff: {_level.Difficulty}");
            print($"Level loop: {_levelLoop}");
            print($"Level random: {_levelRandom}");
            print($"Level type: {_levelType}");
            print($"Game mode: {_gameMode}");
            print("-------------------------------------------------");
        }
        
        public void NextLevel()
        {
            if (_level.Number == 40)
            {
                _levelLoop++;
                print("Next loop");   
            }
            _levelNumber++;
            // print($"Level number: {_levelNumber}");
            // print($"Level now: {_level.Number}");
        }

        private void Start()
        {
            _level = GetComponent<LevelInformation>();
            SendStartStatistics();
        }
    }
}