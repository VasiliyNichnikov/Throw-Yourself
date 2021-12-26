using UnityEngine;

namespace Particulars
{
    public class CreatorOfParticulars : MonoBehaviour
    {
        private Transform _thisTransform;

        public void Create(ActivatorParticle selectedParticle, Vector3 position, Quaternion rotation)
        {
            GameObject newParticle = Instantiate(selectedParticle.gameObject, position, rotation);
            newParticle.transform.SetParent(_thisTransform);
        }
        
        public void Create(ActivatorParticle selectedParticle, Vector3 position)
        {
            GameObject newParticle = Instantiate(selectedParticle.gameObject, position, Quaternion.identity);
            newParticle.transform.SetParent(_thisTransform);
        }

        private void Start()
        {
            _thisTransform = transform;
        }
    }
}