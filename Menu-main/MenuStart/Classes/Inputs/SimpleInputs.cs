using UnityEngine;
namespace Menu.Classes.Inputs
{
    


    internal class SimpleInputs
    {
        #region controller inputs
        // Right controller
        public static bool RightTrigger => ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f;
        public static bool RightGrab => ControllerInputPoller.instance.rightGrab;
        public static bool RightA => ControllerInputPoller.instance.rightControllerSecondaryButton;
        public static bool RightB => ControllerInputPoller.instance.rightControllerSecondaryButton;
        //Left Controller
        public static bool LeftTrigger => ControllerInputPoller.instance.leftControllerIndexFloat > 0.5f;
        public static bool LeftGrab => ControllerInputPoller.instance.leftGrab;
        public static bool LeftX => ControllerInputPoller.instance.leftControllerPrimaryButton;
        public static bool LeftY => ControllerInputPoller.instance.leftControllerSecondaryButton;
        
        //Mouse inputs
        public static bool RightMouseButton => Input.GetMouseButton(1);
        public static bool LeftMouseButton => Input.GetMouseButton(0);
        public static bool RightMouseButtonHeld => Input.GetMouseButton(1);
        public static bool RightMouseButtonPressed => Input.GetMouseButtonDown(1);
        public static bool LeftMouseButtonHeld => Input.GetMouseButton(0);
        public static bool LeftMouseButtonPressed => Input.GetMouseButtonDown(0);
        #endregion
    }
}
