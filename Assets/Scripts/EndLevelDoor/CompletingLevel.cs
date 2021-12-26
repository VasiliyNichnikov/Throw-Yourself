using System.Collections;
using Level;
using Player;
using UnityEngine;

namespace EndLevelDoor
{
    public class CompletingLevel : MonoBehaviour
    {
        [SerializeField] private PushingOutDoor _pushingOutDoor;
        
        private TransitionBetweenLevels _transitionLevels;
        private GameManager _gameManager;
        private int _layerPlayer;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _transitionLevels = FindObjectOfType<TransitionBetweenLevels>();
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
            if (player != null && _gameManager.LevelCompleted && other.gameObject.layer == _layerPlayer)
            {
                _pushingOutDoor.Push();
                StartCoroutine(TimerForMovingToNewScene());
            }
        }

        private IEnumerator TimerForMovingToNewScene()
        {
            yield return new WaitForSeconds(_gameManager.Delay);
            _transitionLevels.LoadToNextScene();
        }
    }
}