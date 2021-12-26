using UnityEngine;

namespace Key
{
    public class CollectorKey : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            ObjectKey key = other.GetComponent<ObjectKey>();
            if (key != null)
            {
                key.Remove();
            }
        }
    }
}