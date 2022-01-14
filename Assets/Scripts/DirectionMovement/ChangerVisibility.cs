using UnityEngine;

namespace DirectionMovement
{
    public class ChangerVisibility : MonoBehaviour
    {
        [SerializeField, Header("Компоненты, которые нужно скрыть")] private Transform[] _objs;
        private Transform _thisTransform;

        private void Awake()
        {
            _thisTransform = transform;
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
