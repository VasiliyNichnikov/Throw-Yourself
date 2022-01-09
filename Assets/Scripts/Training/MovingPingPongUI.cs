using System;
using UnityEngine;

namespace Training
{
    public class MovingPingPongUI : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [SerializeField, Header("Точка до которой будет двигаться курсор")]
        private Vector3 _end;

        [SerializeField] private Transform _canvas;
        [SerializeField] private RectTransform _rectTestImage;
        private Vector3 _start;
        private RectTransform _rect;

        private void Start()
        {
            _rect = GetComponent<RectTransform>();
            _start = _rect.transform.position;
            _end = _start;
            
            // print(_rect.transform.localPosition);
            // print(_rect.transform.position);
        }

        private void Update()
        {
            print(_rect.transform.localPosition);
            _rectTestImage.localPosition =  new Vector3(0, _canvas.InverseTransformPoint(_end).y, 0);;
        }
        
        private void OnDrawGizmos()
        {
            if (_start != Vector3.zero)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(_start, 0.01f);

                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(_end, 0.01f);
            }

            if (_camera != null)
            {
                Gizmos.color = Color.green;
                Vector3 rightUp = _camera.ViewportToWorldPoint(new Vector3(1, 1, 1));
                Gizmos.DrawSphere(rightUp, 0.01f);
            }
        }
    }
}