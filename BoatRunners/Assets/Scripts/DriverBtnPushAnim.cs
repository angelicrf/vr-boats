using System.Collections;
using UnityEngine;

public class DriverBtnPushAnim : MonoBehaviour
{
    private bool isStartedBtn = false;
    void FixedUpdate()
    {
        if (!isStartedBtn)
        {
            StartCoroutine(DriverBTNCo());
        }
    }
    private IEnumerator DriverBTNCo()
    {
        if (!gameObject.GetComponent<AudioSource>().enabled || !gameObject.GetComponent<Animator>().enabled)
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
        }
        yield return new WaitForSeconds(1f);
        if (gameObject.GetComponent<AudioSource>().enabled && gameObject.GetComponent<Animator>().enabled)
        {
            if (!isStartedBtn)
            {
                gameObject.GetComponent<Animator>().SetBool("isBtnPushed", true);
                isStartedBtn = true;
            }
        }
    }
}
