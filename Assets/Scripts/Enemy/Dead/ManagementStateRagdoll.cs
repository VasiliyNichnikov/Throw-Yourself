using UnityEngine;

namespace Enemy.Dead
{
    public class ManagementStateRagdoll : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _allRB;
        [SerializeField] private Collider[] _allColliders;

        public void Destruction()
        {
            ChangeStateRBsAndColliders(true);
        }

        private void Start()
        {
            ChangeStateRBsAndColliders(false);
        }

        private void ChangeStateRBsAndColliders(bool state)
        {
            ChangeStateRBs(state);
            ChangeStateColliders(state);
        }

        private void ChangeStateRBs(bool state)
        {
            foreach (var rb in _allRB)
            {
                rb.isKinematic = !state;
                rb.useGravity = state;
            }
        }

        private void ChangeStateColliders(bool state)
        {
            foreach (var collider in _allColliders)
            {
                collider.enabled = state;
            }
        }
    }
}