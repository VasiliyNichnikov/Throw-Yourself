﻿using System.Collections;
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
            if (player != null && other.gameObject.layer == _layerPlayer && _controllerKey.LevelPassed())
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