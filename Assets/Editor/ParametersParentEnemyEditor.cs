using Enemy;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(BasicParametersEnemy), true)]
    [CanEditMultipleObjects]
    public class ParametersParentEnemyEditor: UnityEditor.Editor
    {
        private BasicParametersEnemy _enemy;
        private Transform _handleTransform;
        private Quaternion _handleRotation;
        
        public void OnEnable()
        {
            _enemy = target as BasicParametersEnemy;
        }

        public void OnSceneGUI()
        {
            _handleTransform = _enemy.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local
                ? _handleTransform.rotation
                : Quaternion.identity;
            
            DrawRadiusParameter("Stopping Distance", _enemy.MinStoppingDistance, Color.green, Color.black);
            DrawRadiusParameter("Attack Distance", _enemy.MinAttackDistance, Color.red, Color.black);
            DrawRadiusParameter("Walking Distance", _enemy.MinWalkingDistance, Color.magenta, Color.black);
            DrawRadiusParameter("Distance to selected point", _enemy.MinDistanceToSelectedPoint, Color.cyan, Color.black);
        }

        private void DrawRadiusParameter(string text, float valueParameter, Color circle, Color label)
        {
            Vector3 circlePosition = _handleTransform.position;
            Vector3 labelPosition = new Vector3(circlePosition.x + valueParameter, 
                circlePosition.y, circlePosition.z);
            
            Handles.color = circle;
            Handles.Label(labelPosition, text);
            Handles.color = label;
            Handles.DrawWireDisc(circlePosition, Vector3.up, valueParameter);
        }
        
        private void DrawRadiusParameter(string text, float valueParameter)
        {
            Vector3 circlePosition = _handleTransform.position;
            Vector3 labelPosition = new Vector3(circlePosition.x + valueParameter, 
                circlePosition.y, circlePosition.z);
            
            Handles.color = Color.black;
            Handles.Label(labelPosition, text);
            Handles.color = Color.white;
            Handles.DrawWireDisc(circlePosition, Vector3.up, valueParameter);
        }
    }
}