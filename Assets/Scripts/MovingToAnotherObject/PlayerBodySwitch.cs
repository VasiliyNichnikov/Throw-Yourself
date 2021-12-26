using Player;
using UnityEngine;

namespace MovingToAnotherObject
{
    public class PlayerBodySwitch : MonoBehaviour
    {
        public bool FirstSwitchBody => _firstSwitchBody;

        [SerializeField, Range(0, 10)] private float _heightRay;
        private SelectedPlayer _selectedPlayer;
        private Transform _thisTransform;
        private ParentPlayer _newPlayer;

        private bool _firstSwitchBody;
        private MeshRenderer _renderer;
        private Vector3 _hitPoint;

        public void BeamThrow(Vector3 direction)
        {
            RaycastHit hit;
            Vector3 center = _renderer.bounds.center;
            // Vector3 thisPosition = _thisTransform.position;
            Vector3 origin = new Vector3(center.x, _heightRay, center.z);
            if (Physics.SphereCast(origin, _selectedPlayer.RadiusRay, direction, out hit,
                    _selectedPlayer.MaxDistance, ~_selectedPlayer.LayerController))
            {
                _hitPoint = hit.point;
                ParentPlayer newPlayer = hit.collider.GetComponent<ParentPlayer>();
                if (newPlayer != null)
                {
                    _newPlayer = newPlayer;
                }
            }
        }

        public void ChangePlayer()
        {
            if (_newPlayer == null) return;
            _firstSwitchBody = true;
            _selectedPlayer.Player.Disconnection(_selectedPlayer.LayerController, _selectedPlayer.PlayerController);
            _selectedPlayer.Player = _newPlayer;
            _selectedPlayer.Player.Connection(_selectedPlayer.LayerPlayer, _selectedPlayer.PlayerSelected);
            _newPlayer = null;
        }

        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            _selectedPlayer = FindObjectOfType<SelectedPlayer>();
            _thisTransform = transform;
        }

        private void OnDrawGizmos()
        {
            if (_selectedPlayer != null && _selectedPlayer.Player != null &&
                _thisTransform == _selectedPlayer.Player.transform)
            {
                Gizmos.color = Color.red;
                Vector3 thisPosition = _thisTransform.position;
                Vector3 center = _renderer.bounds.center;
                Vector3 origin = new Vector3(center.x, _heightRay, center.z);

                Gizmos.DrawWireSphere(origin, _selectedPlayer.RadiusRay);
                Gizmos.DrawLine(origin, _hitPoint);
                Gizmos.DrawWireSphere(_hitPoint, _selectedPlayer.RadiusRay);
            }
        }
    }
}