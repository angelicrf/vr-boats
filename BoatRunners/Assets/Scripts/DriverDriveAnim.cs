using UnityEngine;

public class DriverDriveAnim : MonoBehaviour
{
    public GameObject walkAnim;
    private void FixedUpdate()
    {
        if (BoatOneStatics.isBoatTeleported)
        {
            if (!BoatOneStatics.isBoatOneStartDrive)
            {
                StartCoroutine(DriverStatics.MoveToDriveAnimCo(gameObject, "isDriving", res => BoatOneStatics.isDriveBoatOne = res));
            }
            if (BoatOneStatics.isBoatOneStartDrive && !BoatOneStatics.isDriveBoatOne)
            {
                StartCoroutine(DriverStatics.MoveDriveToWalkAnimCo(gameObject, walkAnim));
            }
        }
    }
}
