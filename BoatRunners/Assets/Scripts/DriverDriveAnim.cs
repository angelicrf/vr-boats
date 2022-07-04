using System.Collections;
using UnityEngine;

public class DriverDriveAnim : MonoBehaviour
{
    public GameObject walkAnim;
    private void FixedUpdate()
    {
        if (!BoatOneStatics.isBoatOneStartDrive)
        {
            StartCoroutine(MoveToDriveAnimCo());
        }
        if (BoatOneStatics.isBoatOneStartDrive && !BoatOneStatics.isDriveBoatOne)
        {
            StartCoroutine(MoveToWalkAnimCo());
        }
    }
    private IEnumerator MoveToWalkAnimCo()
    {
        if (walkAnim)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].wrapMode = WrapMode.Once;
            yield return new WaitForSeconds(5f);
            gameObject.GetComponent<Animator>().enabled = false;
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
            walkAnim.SetActive(true);
        }
    }
        private IEnumerator MoveToDriveAnimCo()
    {
        gameObject.GetComponent<Animator>().SetBool("isDriving", true);
        yield return new WaitForSeconds(12f);
        BoatOneStatics.isDriveBoatOne = true;
    }
}
