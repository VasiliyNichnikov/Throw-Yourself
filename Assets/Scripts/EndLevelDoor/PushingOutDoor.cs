using Sound;
using UnityEngine;

namespace EndLevelDoor
{
    public class PushingOutDoor : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private AudioClip _openDoor;
        private CreatorPlayerSound _creatorPlayerSound;
        private Rigidbody _rb;
        private bool _pushed;


        public void Push()
        {
            if (_pushed)
            {
                return;
            }
            
            _rb.isKinematic = false;
            _pushed = true;
            _creatorPlayerSound.Create(_openDoor);
            _rb.AddForce(Vector3.forward * _force, ForceMode.Force);
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _creatorPlayerSound = FindObjectOfType<CreatorPlayerSound>();
            _pushed = false;
        }

    }
}