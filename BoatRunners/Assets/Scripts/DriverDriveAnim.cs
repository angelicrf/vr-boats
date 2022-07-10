using System.Collections;
using UnityEngine;

public class DriverDriveAnim : MonoBehaviour
{
    public GameObject walkAnim;
    public GameObject thisSeat;
    public GameObject boatMenu;
    private bool isInputDevices = false;
    private bool isEntered = false;

    private void FixedUpdate()
    {
        if (BoatOneStatics.isTeleportCompleted)
            
        {
            gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
            gameObject.transform.localPosition = new Vector3(thisSeat.transform.localPosition.x - 0.1f, -1.24f, thisSeat.transform.localPosition.z + 0.65f);

            if (!BoatOneStatics.isBoatOneStartDrive)
            {
                if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Start"))
                {
                    if (!isEntered)
                    {
                        StartCoroutine(MakeTimeChanges());
                    }
                }
                StartCoroutine(DriverStatics.MoveToDriveAnimCo(gameObject, "isDriving", res => BoatOneStatics.isDriveBoatOne = res));
            }
            if (BoatOneStatics.isBoatOneStartDrive && !BoatOneStatics.isDriveBoatOne && BoatOneStatics.isDrOptionsAuto)
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
    }
    private IEnumerator MakeTimeChanges()
    {
        gameObject.transform.localPosition = new Vector3(thisSeat.transform.localPosition.x - 0.1f, 0, thisSeat.transform.localPosition.z + 0.65f);
        yield return new WaitForSeconds(2f);
        gameObject.transform.localPosition = new Vector3(thisSeat.transform.localPosition.x - 0.1f, -1.24f, thisSeat.transform.localPosition.z + 0.65f);
        isEntered = true;
    }
   
}
