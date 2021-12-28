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
        public int LayerPlayer => MyUtils.GetLayerNumberByMask(_layerPlayer.value);
        public int LayerController => MyUtils.GetLayerNumberByMask(_layerControlled.value);
        public Material PlayerSelected => _playerSelected;
        public Material PlayerController => _playerController;

        [SerializeField] private ParentPlayer _player;
        [SerializeField, Range(0, 5)] private float _radiusRay;
        [SerializeField, Range(0, 50)] private float _maxDistance;
        [SerializeField] private Material _playerSelected;
        [SerializeField] private Material _playerController;
        [SerializeField] private LayerMask _layerPlayer;
        [SerializeField] private LayerMask _layerControlled;

        private void Start()
        {
            _player.Connection(MyUtils.GetLayerNumberByMask(_layerPlayer.value), _playerSelected);
        }

        public void Disconnection()
        {
            _player.Disconnection(MyUtils.GetLayerNumberByMask(_layerControlled.value), _playerController);
        }
    }
}