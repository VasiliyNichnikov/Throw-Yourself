using UnityEngine;

namespace MovingToAnotherObject
{
    public class MaterialLightingSwitch : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private static readonly int _lightingSwitch = Shader.PropertyToID("OnOffLighting");
        private int _controlledLayer;
        
        private void OnEnable()
        {
            _controlledLayer = LayerMask.NameToLayer("Controlled");
            if(gameObject.layer == _controlledLayer)
                EventsMovingToAnotherObject.EventChangeLighting += ChangeLighting;
        }

        private void OnDisable()
        {
            if(gameObject.layer == _controlledLayer)
                EventsMovingToAnotherObject.EventChangeLighting -= ChangeLighting;
        }

        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        private void ChangeLighting(float val)
        {
            if (gameObject.layer != LayerMask.NameToLayer("Player"))
                _renderer.material.SetFloat(_lightingSwitch, val);
        }
    }
}