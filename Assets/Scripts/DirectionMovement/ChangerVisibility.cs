using UnityEngine;

namespace DirectionMovement
{
    public class ChangerVisibility : MonoBehaviour
    {
        private Transform _thisTransform;
        private Transform[] _objs;

        private void Awake()
        {
            _thisTransform = transform;
            _objs = _thisTransform.GetComponentsInChildren<Transform>();
        }

        private void Start()
        {
            ToChange(false);
        }
        
        public void ToChange(bool state)
        {
            foreach (var t in _objs)
            {
                if(t == _thisTransform) continue;
                t.gameObject.SetActive(state);
            }
        }
    }
}
