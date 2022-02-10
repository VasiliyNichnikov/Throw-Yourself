using UnityEngine;
using UnityEngine.SceneManagement;

namespace Analytics
{
    public class LevelInformation : MonoBehaviour
    {
        public int LevelNumber => SceneManager.GetActiveScene().buildIndex + 1;
        public string LevelName => SceneManager.GetActiveScene().name;
        public TypesOfLevelDifficulties LevelDifficulties => _levelDifficulties;
        
        
        [SerializeField, Header("Сложность уровня")]
        private TypesOfLevelDifficulties _levelDifficulties;
        
    }
}