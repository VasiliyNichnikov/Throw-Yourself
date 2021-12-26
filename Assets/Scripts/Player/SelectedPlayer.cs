using System;
using UnityEngine;

namespace Player
{
    public class SelectedPlayer : MonoBehaviour
    {
        public ParentPlayer Main
        {
            get
            {
                if (_player == null) throw new Exception("Player not found");
                return _player;
            }
            set
            {
                if (value != null) _player = value;
            }
        }

        public float RadiusRay => _radiusRay;
        public float MaxDistance => _maxDistance;
        public int LayerPlayer => _layerPlayer;
        public int LayerController => _layerControlled;
        public Material PlayerSelected => _playerSelected;
        public Material PlayerController => _playerController;

        [SerializeField] private ParentPlayer _player;
        [SerializeField, Range(0, 5)] private float _radiusRay;
        [SerializeField, Range(0, 50)] private float _maxDistance;
        [SerializeField] private Material _playerSelected;
        [SerializeField] private Material _playerController;
        private int _layerPlayer;
        private int _layerControlled;

        private void Start()
        {
            _layerPlayer = LayerMask.NameToLayer("Player"); // TODO Сделать выбор слоя в unity или создать общий скрипт 
            _layerControlled = LayerMask.NameToLayer("Controlled"); // TODO Сделать выбор слоя в unity или создать общий скрипт 
            _player.Connection(_layerPlayer, _playerSelected);
        }

        public void Disconnection()
        {
            _player.Disconnection(_layerControlled, _playerController);
        }
    }
}