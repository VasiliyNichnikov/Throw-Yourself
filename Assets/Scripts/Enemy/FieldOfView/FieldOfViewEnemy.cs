using UnityEngine;

namespace Enemy.FieldOfView
{
    [RequireComponent(typeof(MeshFilter))]
    public class FieldOfViewEnemy : MonoBehaviour
    {
        public float ViewDistance { 
            get => _viewDistance; 
            set
            {
                if (value >= 0) _viewDistance = value;
            } 
        }
        public float Fov => _fov;

        [SerializeField] private LayerMask _layerMask;
        [SerializeField, Range(-180, 180)] private float _fov;
        [SerializeField, Range(1, 1000)] private int _rayCount;
        private float _viewDistance;

        private Mesh _mesh;
        private Vector3 _origin;
        private Transform _thisTransform;

        private void Start()
        {
            _mesh = new Mesh();
            _thisTransform = transform;
            GetComponent<MeshFilter>().mesh = _mesh;
            _origin = _thisTransform.position;
        }

        private void LateUpdate()
        {
            CreatingMesh();
        }

        private void CreatingMesh()
        {
            float angle = -_thisTransform.rotation.eulerAngles.y;
            float angleIncrease = _fov / _rayCount;
            _origin = _thisTransform.position;

            Vector3[] vertices = new Vector3[_rayCount + 2];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[_rayCount * 3];

            vertices[0] = _thisTransform.InverseTransformPoint(_origin);

            int vertexIndex = 1;
            int triangleIndex = 0;

            for (int i = 0; i <= _rayCount; i++)
            {
                Vector3 vertex;
                Ray ray = new Ray(_origin, -MyUtils.GetVectorFromAngle(angle));
                Physics.Raycast(ray, out var hit, _viewDistance, _layerMask);

                if (hit.collider == null)
                {
                    vertex = _origin - MyUtils.GetVectorFromAngle(angle) * _viewDistance;
                }
                else
                {
                    vertex = hit.point;
                }
            
                vertices[vertexIndex] = _thisTransform.InverseTransformPoint(vertex);

                uv[vertexIndex] = Vector2.up;
                if (i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }

                vertexIndex++;
                angle -= angleIncrease;
            }

            _mesh.vertices = vertices;
            _mesh.uv = uv;
            _mesh.triangles = triangles;
        }

        private void OnDrawGizmosSelected()
        {
            if (_thisTransform == null) _thisTransform = transform;
            Vector3 origin = _thisTransform.position;
            Vector3 newOrigin = new Vector3(origin.x, 0.2f, origin.z);

            Gizmos.color = Color.yellow;
            float angle = -_thisTransform.rotation.eulerAngles.y;
            float angleIncrease = _fov / _rayCount;

            for (int i = 0; i <= _rayCount; i++)
            {
                Vector3 direction = -MyUtils.GetVectorFromAngle(angle) * _viewDistance;

                Vector3 newDirection = new Vector3(direction.x, 0.2f, direction.z);
                Gizmos.DrawRay(newOrigin, newDirection);
                angle -= angleIncrease;
            }
        }
    }
}