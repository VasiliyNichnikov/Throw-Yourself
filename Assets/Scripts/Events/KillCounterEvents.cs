using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class KillCounterEvents : MonoBehaviour, IMyEvent
    {
        public UnityEvent AddValueToTextCounter { get; private set; }
        
        public void Init()
        {
            AddValueToTextCounter = new UnityEvent();
        }
    }
}