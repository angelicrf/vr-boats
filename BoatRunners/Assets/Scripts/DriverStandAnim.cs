using System.Collections;
using UnityEngine;

public class DriverStandAnim : MonoBehaviour
{
    private bool isDrStanding = false;
    private void FixedUpdate()
    {
        if (!isDrStanding)
        {
            StartCoroutine(MoveToStandAnimCo());
            isDrStanding = false;
        }
    }

    private IEnumerator MoveToStandAnimCo()
    {
        gameObject.GetComponent<Animator>().SetBool("isStanding", true);
        yield return new WaitForSeconds(12f);
        Debug.Log("standing...");
        //display audio 
        //move to walk
        //display audio for boat info
    }
}
