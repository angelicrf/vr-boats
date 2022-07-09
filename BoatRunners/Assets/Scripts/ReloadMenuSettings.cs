using UnityEngine;

public class ReloadMenuSettings : MonoBehaviour
{
    private bool isInputDevices = false;
    public GameObject boatMenu;
    private void FixedUpdate()
    {
        if (!BoatOneStatics.isTeleportCompleted)
        {
            if (!isInputDevices)
            {
                isInputDevices = DriverStatics.GetInputDevices();
            }
            if (isInputDevices && boatMenu)
            {
                DriverStatics.ReactivateBoatMenu(boatMenu);
            }
        }
    }
   
}
