using System.Collections;
using UnityEngine;

public class TeleportPosition : MonoBehaviour
{
    [SerializeField]
    public GameObject thisPlayer;
    private bool isTeleported = false;
    private bool isBoatTeleported = false;
    public GameObject parentObj;
    private bool processTel = false;
    private void FixedUpdate()
    {
        if (isTeleported && !isBoatTeleported)
        {
            StartCoroutine( ChangeTelPosCo() );           
        }
        else if (isBoatTeleported && !isTeleported)
        {
            if (parentObj)
            {
                thisPlayer.transform.parent = parentObj.transform;
            }
            StartCoroutine( ChangeTelBoatPosCo() );
        }
    }
    IEnumerator ChangeTelBoatPosCo()
    {
        yield return new WaitForSeconds( 2f );
        thisPlayer.transform.position = new Vector3( thisPlayer.transform.position.x , 3f , thisPlayer.transform.position.z );
    }
    IEnumerator ChangeTelPosCo()
    {
        yield return new WaitForSeconds( 2f );
        thisPlayer.transform.position = new Vector3( thisPlayer.transform.position.x , 4f , thisPlayer.transform.position.z );

    }
    public void PlayerTeleportPos()
    {
        if (thisPlayer)
        {
            isTeleported = true;
        }
    }
    public void PlayerTeleportPosExit()
    {
        if (thisPlayer)
        {
            isTeleported = false;
        }
    }
    public void PlayerTeleportBoatPos()
    {
        if (thisPlayer)
        {
            isBoatTeleported = true;
        }
    }
    public void PlayerTeleportBoatExit()
    {
        if (thisPlayer)
        {
            isBoatTeleported = false;
        }
    }

}
