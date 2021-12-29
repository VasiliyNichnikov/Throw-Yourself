using UnityEngine;

namespace Interaction
{
    public class DrawingLineBetweenPoints : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        private Camera _camera;
        private InteractionWithScreen _interactionWithScreen;

        private void Start()
        {
            _camera = Camera.main;
            _interactionWithScreen = GetComponent<InteractionWithScreen>();
        }

        private void OnDrawGizmos()
        {
            if (_camera == null || _canvas == null) return;
            Vector3 start = GetWorldPosition(_interactionWithScreen.PositionStart);
            Vector3 end = GetWorldPosition(_interactionWithScreen.PositionEnd);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(start, 0.01f);
            Gizmos.DrawSphere(end, 0.01f);
            Gizmos.DrawLine(start, end);
        }

        private Vector3 GetWorldPosition(Vector3 screen)
        {
            Vector3 newPosition = new Vector3(screen.x, screen.y, _canvas.planeDistance);
            return _camera.ScreenToWorldPoint(newPosition);
        }
    }
}