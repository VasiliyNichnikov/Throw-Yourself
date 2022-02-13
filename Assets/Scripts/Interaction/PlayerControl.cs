using Player;
using Player.FeedBacks;
using UnityEngine;

namespace Interaction
{
    public class PlayerControl : MonoBehaviour
    {
        private SelectedPlayer _player;
        private ConnectingFeedBacks _feedBacks;

        public void Push(Vector3 direction)
        {
            _player.Main.Engine.Push(direction);
            _feedBacks.PlayPushFeedBack(direction);
        }

        public void ChangeBody()
        {
            _player.Main.BodySwitch.MoveToNew();
        }

        private void Start()
        {
            _player = FindObjectOfType<SelectedPlayer>();
            _feedBacks = _player.Main.GetComponent<ConnectingFeedBacks>();
        }
    }
}