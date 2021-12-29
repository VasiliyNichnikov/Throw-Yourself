using System;

namespace Events
{
    public class InteractionWithScreenEvents
    {
        public event Action PointerDown;
        public event Action PointerDrag;
        public event Action PointerUp;

        public void LauncherPointerDown()
        {
            PointerDown?.Invoke();
        }

        public void LauncherPointerDrag()
        {
            PointerDrag?.Invoke();
        }

        public void LauncherPointerUp()
        {
            PointerUp?.Invoke();
        }
    }
}