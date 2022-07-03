using System.Collections;
using UnityEngine;

public class DriverDriveAnim : MonoBehaviour
{
    private bool isStartDrive = false;
    private void FixedUpdate()
    {
        if (!isStartDrive)
        {
            StartCoroutine(MoveToDriveAnimCo());
            isStartDrive = true;
        }
    }
    private IEnumerator MoveToDriveAnimCo()
    {
        gameObject.GetComponent<Animator>().SetBool("isDriving", true);
        yield return new WaitForSeconds(12f);
        BoatOneStatics.isDriveBoatOne = true;
    }
}
