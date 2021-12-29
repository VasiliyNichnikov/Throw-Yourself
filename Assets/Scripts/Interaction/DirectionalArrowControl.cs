using DirectionMovement;
using Player;
using UnityEngine;

namespace Interaction
{
    public class DirectionalArrowControl : MonoBehaviour
    {
        private SelectedPlayer _player;

        public void ToCreate(TypesArrow type)
        {
            _player.Main.InteractionArrow.Install(type);
        }
        
        public void Move()
        {
            _player.Main.InteractionArrow.ChangePosition();
        }
        
        public void Rotate(Vector3 direction)
        {
            _player.Main.InteractionArrow.ChangeAngleZ(direction);
        }

        public void Stretch(Vector3 direction)
        {
            _player.Main.InteractionArrow.Stretch(direction);
        }

        public void LaunchDisplacementBeam(Vector3 direction)
        {
            _player.Main.BodySwitch.BeamThrow(direction);
        }

        public void Show()
        {
            _player.Main.InteractionArrow.SetVisible(true);
        }

        public void Remove()
        {
            _player.Main.InteractionArrow.Remove();
        }
        
        private void Start()
        {
            _player = FindObjectOfType<SelectedPlayer>();
        }
    }
}