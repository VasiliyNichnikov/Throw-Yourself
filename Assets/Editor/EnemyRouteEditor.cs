using Enemy.Rifle;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(EnemyRoute))]
    public class EnemyRouteEditor : UnityEditor.Editor
    {
        private EnemyRoute _parameters;
        private Transform _handleTransform;
        private Quaternion _handleRotation;

        private void OnSceneGUI()
        {
            _parameters = target as EnemyRoute;
            if (_parameters == null) return;

            _handleTransform = _parameters.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local
                ? _handleTransform.rotation 
                : Quaternion.identity;

            if (_parameters.MovingPoints == null || _parameters.MovingPoints.Length <= 1) return;

            for (int i = 0; i < _parameters.MovingPoints.Length - 1; i++)
            {
                Vector3 pNow = ShowPoint(i);
                Vector3 pNext = ShowPoint(i + 1);
                Handles.color = Color.red;
                Handles.DrawLine(pNow, pNext);
            }

            if (_parameters.MovingPoints.Length > 2)
            {
                Vector3 pFirst = ShowPoint(0);
                Vector3 pLast = ShowPoint(_parameters.MovingPoints.Length - 1);
                Handles.DrawLine(pFirst, pLast);
            }
        }

        private Vector3 ShowPoint(int index)
        {
            Vector3 point = _handleTransform.TransformPoint(_parameters.MovingPoints[index]);
            EditorGUI.BeginChangeCheck();
            point = Handles.DoPositionHandle(point, _handleRotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_parameters, "Move point");
                EditorUtility.SetDirty(_parameters);
                _parameters.MovingPoints[index] = _handleTransform.InverseTransformPoint(point);
            }

            return point;
        }
    }
}