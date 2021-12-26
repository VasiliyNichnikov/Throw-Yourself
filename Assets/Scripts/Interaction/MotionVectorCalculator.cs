using UnityEngine;

namespace Interaction
{
    public class MotionVectorCalculator
    {
        private Camera _camera;
        private float _sensitivity;

        public MotionVectorCalculator(Camera cam, float sensitivity)
        {
            _camera = cam;
            _sensitivity = sensitivity;
        }

        public Vector3 GetDirectionsFromScreen(Vector3 posStart, Vector3 posEnd)
        {
            posStart = _camera.ScreenToViewportPoint(posStart);
            posEnd = _camera.ScreenToViewportPoint(posEnd);
            Vector3 direction = (posEnd - posStart) * _sensitivity;
            direction = ClampDirection(direction);
            return new Vector3(-direction.x, 0, -direction.y);
        }

        private Vector3 ClampDirection(Vector3 direction)
        {
            direction.x = Mathf.Clamp(direction.x, -1, 1);
            direction.y = Mathf.Clamp(direction.y, -1, 1);
            return direction;
        }
    }
}