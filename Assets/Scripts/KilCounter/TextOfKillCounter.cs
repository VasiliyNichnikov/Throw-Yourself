using Events;
using UnityEngine;
using UnityEngine.UI;

namespace KilCounter
{
    public class TextOfKillCounter : MonoBehaviour
    {
        private int _counter = 0;
        private Text _textCounter;
        private EventKeeper _eventKeeper;


        private void Start()
        {
            _counter = 0;
            _textCounter = GetComponent<Text>();
            _eventKeeper = FindObjectOfType<EventKeeper>();
            _eventKeeper.KillCounter.AddValueToTextCounter.AddListener(AddingKill);
            UpdateText();
        }

        private void AddingKill()
        {
            _counter++;
            UpdateText();
        }
        private void UpdateText()
        {
            _textCounter.text = _counter.ToString();
        }
    }
}