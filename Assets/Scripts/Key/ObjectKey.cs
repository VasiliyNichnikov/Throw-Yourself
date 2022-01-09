using System.Collections;
using Sound;
using UnityEngine;

namespace Key
{
    public class ObjectKey : MonoBehaviour
    {
        [SerializeField, Header("Задержка прежде чем удалить ключ")]
        private float _delay;

        [SerializeField, Header("Звук при подборе ключа")]
        private AudioClip _keySelection;

        private CreatorPlayerSound _creatorPlayerSound;


        public void Remove()
        {
            Destroy(this.gameObject);
        }

        private void Start()
        {
            _creatorPlayerSound = FindObjectOfType<CreatorPlayerSound>();
            StartCoroutine(LaunchingDestroyer());
        }

        private IEnumerator LaunchingDestroyer()
        {
            yield return new WaitForSeconds(_delay);
            _creatorPlayerSound.Create(_keySelection);
            Destroy(this.gameObject);
        }
    }
}