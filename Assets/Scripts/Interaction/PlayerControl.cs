using Player;
using UnityEngine;

namespace Interaction
{
    public class PlayerControl : MonoBehaviour
    {
        private SelectedPlayer _player;

        public void Push(Vector3 direction)
        {
            _player.Main.Engine.Push(direction);
            _player.Main.FeedBacks.PlayThrowingPlayer();
        }

        public void ChangeBody()
        {
            _player.Main.BodySwitch.MoveToNew();
        }

        private void Start()
        {
            _player = FindObjectOfType<SelectedPlayer>();
        }
    }
}