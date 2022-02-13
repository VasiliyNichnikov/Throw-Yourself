using System;
using Facebook.Unity;
using UnityEngine;

namespace Analytics
{
    public class InitializationFacebook : MonoBehaviour
    {
        private void Awake()
        {
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
            }
            else
            {
                FB.Init(FB.ActivateApp);
            }
        }
    }
}