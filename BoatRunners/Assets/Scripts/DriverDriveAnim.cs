using UnityEngine;

public class DriverDriveAnim : MonoBehaviour
{
    public GameObject walkAnim;
    public GameObject thisSeat;
    public GameObject boatMenu;
    private bool isInputDevices = false;

    private void FixedUpdate()
    {
        if (BoatOneStatics.isTeleportCompleted)
            
        {
            gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
            gameObject.transform.localPosition = new Vector3( thisSeat.transform.localPosition.x -0.1f,-1.25f,thisSeat.transform.localPosition.z + 0.65f);
            if (!BoatOneStatics.isBoatOneStartDrive)
            {
                StartCoroutine(DriverStatics.MoveToDriveAnimCo(gameObject, "isDriving", res => BoatOneStatics.isDriveBoatOne = res));
            }
            if (BoatOneStatics.isBoatOneStartDrive && !BoatOneStatics.isDriveBoatOne)
            {
                StartCoroutine(DriverStatics.MoveDriveToWalkAnimCo(gameObject, walkAnim));
            }
            if (!isInputDevices)
            {
                isInputDevices = DriverStatics.GetInputDevices();
            }
            if (isInputDevices && boatMenu)
            {
                DriverStatics.ReactivateBoatMenu(boatMenu);
            }
        }
        //else
        //{
        //    
        //}
    }
}
