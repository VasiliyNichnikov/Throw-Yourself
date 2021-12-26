using System.Collections;
using UnityEngine;

namespace Enemy.FieldOfView
{
    public class AnalyzerOfPlayerGettingIntoZone : MonoBehaviour
    {
        public bool InArea => _inArea;

        [SerializeField] private Transform _body;
        [SerializeField] private Transform _visibilityAreaDirection;

        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private LayerMask _obstacleMask;

        [SerializeField]private bool _inArea;
        private FieldOfViewEnemy _fieldOfView;
        private Transform _thisTransform;


        private void Start()
        {
            _fieldOfView = GetComponent<FieldOfViewEnemy>();
            StartCoroutine(FindTargetsWithDelay(0.1f));
            _thisTransform = transform;
        }

        private IEnumerator FindTargetsWithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
            }
        }

        private void FindVisibleTargets()
        {
            _inArea = false;
            
            Collider[] targetsInViewRadius =
                Physics.OverlapSphere(_thisTransform.position, _fieldOfView.ViewDistance, _targetMask);
            foreach (var t in targetsInViewRadius)
            {
                Transform target = t.transform;
                Vector3 directoryToTarget = (target.position - _thisTransform.position).normalized;
                Vector3 from = _visibilityAreaDirection.position - _body.position;
                // print(Vector3.Angle(from, directoryToTarget));
                if ((Vector3.Angle(from, directoryToTarget) < _fieldOfView.Fov / 2) == false) continue;
                float distanceToTarget = Vector3.Distance(_thisTransform.position, target.position);
                if (Physics.Raycast(_thisTransform.position, directoryToTarget, distanceToTarget, _obstacleMask) ==
                    false)
                {
                    _inArea = true;
                }
            }
        }
    }
}