using UnityEngine;

namespace Enemy.Dead
{
    public class DestroyerOfVisualizationComponents : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objectsToDelete;

        public void Destruction()
        {
            if(_objectsToDelete.Length == 0) return;
            foreach (var obj in _objectsToDelete)
            {
                Destroy(obj);
            }
        }
    }
}
