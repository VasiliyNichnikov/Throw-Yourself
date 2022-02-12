using System.Collections;
using Analytics;
using Key;
using Level;
using Player;
using UnityEngine;

namespace EndLevelDoor
{
    public class CompletingLevel : MonoBehaviour
    {
        [SerializeField] private PushingOutDoor _pushingOutDoor;
        
        private TransitionBetweenLevels _transitionLevels;
        private ControllerKey _controllerKey;
        private GameManager _gameManager;
        private IEnumerator _transitionTimer;
        private int _layerPlayer;


        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _transitionLevels = FindObjectOfType<TransitionBetweenLevels>();
            _controllerKey = FindObjectOfType<ControllerKey>();
            _layerPlayer = LayerMask.NameToLayer("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckingCompleteLevel(other);
        }

        private void OnTriggerStay(Collider other)
        {
            CheckingCompleteLevel(other);
        }

        private void CheckingCompleteLevel(Collider other)
        {
            ParentPlayer player = other.GetComponent<ParentPlayer>();
            if (player != null && other.gameObject.layer == _layerPlayer && _controllerKey.LevelPassed() && 
                _transitionTimer == null)
            {
                _pushingOutDoor.Push();
                _transitionTimer = TimerForMovingToNewScene();
                StartCoroutine(_transitionTimer);
            }
        }

        private IEnumerator TimerForMovingToNewScene()
        {
            yield return new WaitForSeconds(_gameManager.Delay);
            _transitionLevels.LoadToNextScene();
        }
    }
}