using Player;
using UnityEngine;

namespace MovingToAnotherObject
{
    public class BodySwitchPlayer : MonoBehaviour
    {
        public bool FirstSwitchBody => _firstSwitchBody; // TODO Удалить переменную (Была сделанна для обучения)

        [SerializeField, Range(0, 10)] private float _heightRay;
        private SelectedPlayer _selectedPlayer;
        private Transform _thisTransform;
        private ParentPlayer _newPlayer;

        private bool _firstSwitchBody;
        private MeshRenderer _renderer;
        private Vector3 _hitPoint;

        /// <summary>
        /// Пускает луч и если луч попадает в объект, в который можно переместиться,
        /// сохраняем этого игрока в отдельную переменную
        /// </summary>
        /// <param name="direction">Направление луча</param>
        public void BeamThrow(Vector3 direction)
        {
            Vector3 center = _renderer.bounds.center;
            Vector3 origin = new Vector3(center.x, _heightRay, center.z);
            if (Physics.SphereCast(origin, _selectedPlayer.RadiusRay, direction, out var hit,
                    _selectedPlayer.MaxDistance, ~_selectedPlayer.LayerController) == false) return;
            _hitPoint = hit.point;
            ParentPlayer newPlayer = hit.collider.GetComponent<ParentPlayer>();
            if (newPlayer != null)
            {
                _newPlayer = newPlayer;
            }
        }
        
        
        /// <summary>
        /// Если новое тело выбрано, меняем тело игрока на новое
        /// </summary>
        public void MoveToNew()
        {
            if (_newPlayer == null) return;
            _firstSwitchBody = true;
            _selectedPlayer.Main.Disconnection(_selectedPlayer.LayerController, _selectedPlayer.PlayerController);
            _selectedPlayer.Main = _newPlayer;
            _selectedPlayer.Main.Connection(_selectedPlayer.LayerPlayer, _selectedPlayer.PlayerSelected);
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
            if (_selectedPlayer != null && _selectedPlayer.Main != null &&
                _thisTransform == _selectedPlayer.Main.transform)
            {
                Gizmos.color = Color.red;
                Vector3 center = _renderer.bounds.center;
                Vector3 origin = new Vector3(center.x, _heightRay, center.z);

                Gizmos.DrawWireSphere(origin, _selectedPlayer.RadiusRay);
                Gizmos.DrawLine(origin, _hitPoint);
                Gizmos.DrawWireSphere(_hitPoint, _selectedPlayer.RadiusRay);
            }
        }
    }
}