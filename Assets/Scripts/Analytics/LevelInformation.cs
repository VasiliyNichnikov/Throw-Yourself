using UnityEngine;
using UnityEngine.SceneManagement;

namespace Analytics
{
    public class LevelInformation : MonoBehaviour
    {
        public int Number => SceneManager.GetActiveScene().buildIndex + 1;
        public string Name => SceneManager.GetActiveScene().name;
        public TypesOfLevelDifficulties Difficulty => _difficulty;

        [SerializeField, Header("Сложность уровня")]
        private TypesOfLevelDifficulties _difficulty;
        
    }
}