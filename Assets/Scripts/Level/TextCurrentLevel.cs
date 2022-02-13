using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    public class TextCurrentLevel : MonoBehaviour
    {
        [SerializeField, Header("Текст, которы будет идти после цифры уровня")]
        private string _additionalTextAfterNumber;
        
        private Text _text;
        private const string _levelNumberKey = "levelNumber"; // TODO костыль, название переменной используется в скрипте LevelInformation

        private void Start()
        {
            _text = GetComponent<Text>();
            _text.text = WorkingWithPlayerPrefs.GetDataInt(_levelNumberKey).ToString() + _additionalTextAfterNumber;
        }
    }
}