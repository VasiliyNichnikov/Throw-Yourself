using UnityEngine;

namespace PhysicsObjects
{
    public class RendererOfImportantComponents : MonoBehaviour
    {
        private Transform _thisTransform;
        private MeshCollider _collider;

        private void OnDrawGizmosSelected()
        {
            _thisTransform = GetComponent<Transform>();
            _collider = GetComponent<MeshCollider>();
            if (_thisTransform == null || _collider == null) return;

            DrawCenterObject();
        }

        private void DrawCenterObject()
        {
            Vector3 center = _collider.bounds.center;
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(center, 0.2f);
        }
    }
}