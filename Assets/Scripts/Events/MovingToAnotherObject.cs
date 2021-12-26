using UnityEngine;

namespace Events
{
    public class MovingToAnotherObject : MonoBehaviour, IMyEvent
    {
        public MyFloatEvent Glow => _glow;
        private MyFloatEvent _glow;

        public void Init()
        {
            _glow = new MyFloatEvent();
        }
    }
}