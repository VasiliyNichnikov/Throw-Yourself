using System.Collections;
using Sound;
using UnityEngine;

namespace Key
{
    public class ObjectKey : MonoBehaviour
    {
        [SerializeField, Header("Задержка прежде чем включить коллайдер")]
        private float _delay;

        [SerializeField, Header("Звук при подборе ключа")]
        private AudioClip _keySelection;

        private CreatorPlayerSound _creatorPlayerSound;
        private BoxCollider _collider;


        public void Remove()
        {
            Destroy(this.gameObject);
        }

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
            _creatorPlayerSound = FindObjectOfType<CreatorPlayerSound>();
            StartCoroutine(LaunchingCollider());
        }

        private IEnumerator LaunchingCollider()
        {
            yield return new WaitForSeconds(_delay);
            _collider.enabled = true;
        }

        private void OnDestroy()
        {
            _creatorPlayerSound.Create(_keySelection);
            EventsKey.LauncherEventAddKey();
        }
    }
}