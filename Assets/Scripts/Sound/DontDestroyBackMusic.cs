using UnityEngine;

namespace Sound
{
    public class DontDestroyBackMusic : MonoBehaviour
    {
        private void Awake()
        {
            BackMusic[] objs = FindObjectsOfType<BackMusic>();

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
    }
}