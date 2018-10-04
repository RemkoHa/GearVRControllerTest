namespace VRTK.Examples
{
    using UnityEngine;

    public class RC_Car_Controller : MonoBehaviour
    {
        //gameobject car
        public GameObject rcCar;
        //private var for car script
        private RC_Car rcCarScript;

        private void Start()
        {
            //get script from car
            rcCarScript = rcCar.GetComponent<RC_Car>();
            //add eventhandlers for trigger axis changed and touchpadAxisChanged
            GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
            GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);
            //add eventhandlers for trigger released and touchpad touch end
            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);
            //add eventhandler for button press
            GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoCarReset);
        }
        //function for axis changed
        private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTouchAxis(e.touchpadAxis);
        }
        //function for trigger axis changed
        private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTriggerAxis(e.buttonPressure);
        }
        //function for touchpad touch end
        private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTouchAxis(Vector2.zero);
        }
        //trigger released function
        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTriggerAxis(0f);
        }
        //car reset function
        private void DoCarReset(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.ResetCar();
        }
    }
}