using UnityEngine;

namespace Sound
{
    public class CreatorPlayerSound : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabPlayerSound;
        private Transform _thisTransform;

        public void Create(AudioClip clip, float volume=1.0f)
        {
            PlayerSound newPlayerSound =
                Instantiate(_prefabPlayerSound, _thisTransform.position, Quaternion.identity).GetComponent<PlayerSound>();
            newPlayerSound.TurnOn(clip, volume);
        }

        private void Start()
        {
            _thisTransform = transform;
        }
    }
}