using Events;
using Player;
using UnityEngine;

namespace MovingToAnotherObject
{
    public class MaterialLightingSwitch : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private Events.MovingToAnotherObject _event;
        private ParentPlayer _player;

        private static readonly int
            LightingSwitch = Shader.PropertyToID("OnOffLighting"); // TODO вынести в отдельный статический класс

        private void Start()
        {
            _player = GetComponent<ParentPlayer>();
            if (_player.Parameters.RelocationIsAllowed)
            {
                _event = FindObjectOfType<EventKeeper>().MovingToAnotherObject;
                _event.Glow.AddListener(ChangeLighting);
                _renderer = GetComponent<MeshRenderer>();
            }
        }

        private void ChangeLighting(float val)
        {
            if (gameObject.layer != LayerMask.NameToLayer("Player")) // TODO Сделать выбор слоя из Unity 
                _renderer.material.SetFloat(LightingSwitch, val);
        }
    }
}