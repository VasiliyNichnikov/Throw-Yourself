using Map;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(MapBoundaries))]
    public class MapBoundariesEditor : UnityEditor.Editor
    {
        private MapBoundaries _boundaries;
        private Transform _handleTransform;
        private Quaternion _handleRotation;

        private void OnSceneGUI()
        {
            _boundaries = target as MapBoundaries;
            if (_boundaries == null) return;
            
            _handleTransform = _boundaries.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local
                ? _handleTransform.rotation
                : Quaternion.identity;

            for (int i = 0; i < _boundaries.Points.Length; i++)
            {
               ShowPoint(i);
            }
            
            Handles.color = Color.black;
            float sizeCubeX = Mathf.Abs(_boundaries.Points[0].x - _boundaries.Points[1].x);
            float sizeCubeY = _boundaries.Points[0].y;
            float sizeCubeZ = Mathf.Abs(_boundaries.Points[0].z - _boundaries.Points[1].z);
            Vector3 center = new Vector3(_boundaries.Points[0].x - sizeCubeX / 2,
                _boundaries.Points[0].y / 2, _boundaries.Points[0].z - sizeCubeZ / 2);
            Handles.DrawWireCube(center, new Vector3(sizeCubeX, sizeCubeY, sizeCubeZ));
        }

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            if (GUILayout.Button("Calculate points"))
            {
                _boundaries.CalculatePointsBoundaries();
            }
        }

        private void ShowPoint(int index)
        {
            Vector3 point = _handleTransform.TransformPoint(_boundaries.Points[index]);
            EditorGUI.BeginChangeCheck();
            point = Handles.DoPositionHandle(point, _handleRotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_boundaries, "Move point");
                EditorUtility.SetDirty(_boundaries);
                _boundaries.Points[index] = _handleTransform.InverseTransformPoint(point);
            }
        }
    }
}