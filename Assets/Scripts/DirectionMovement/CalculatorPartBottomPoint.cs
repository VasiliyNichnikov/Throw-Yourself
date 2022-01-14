using UnityEngine;

namespace DirectionMovement
{
    public class CalculatorPartBottomPoint : MonoBehaviour
    {
        private Transform _thisTransform;
        private MeshFilter _filter;
        private Bounds _bounds;
        private Vector3 _boundsCenter;


        public Vector3 GetTopmostPointZ()
        {
            Vector3 topmostZ = new Vector3(_boundsCenter.x, _boundsCenter.y, Mathf.Infinity);
            topmostZ = _thisTransform.TransformPoint(_bounds.ClosestPoint(topmostZ));
            return topmostZ;
        }

        private void Awake()
        {
            _thisTransform = transform;
            _filter = GetComponent<MeshFilter>();
            _bounds = _filter.mesh.bounds;
            _boundsCenter = _bounds.center;
            ResetScale();
        }

        private void ResetScale()
        {
            Vector3 localScale = _thisTransform.localScale;
            _thisTransform.localScale = new Vector3(localScale.x, localScale.y, 0);
        }

        private void OnDrawGizmosSelected()
        {
            if (_filter == null) return;
            Vector3 topmostZ = GetTopmostPointZ();
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(topmostZ, 0.2f);
        }
    }
}