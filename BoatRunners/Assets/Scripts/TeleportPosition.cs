using System.Collections;
using UnityEngine;

public class TeleportPosition : MonoBehaviour
{
    [SerializeField]
    public GameObject thisPlayer;
    private bool isTeleported = false;
    public GameObject parentObj;
    private void FixedUpdate()
    {
        if (isTeleported && !BoatOneStatics.isBoatTeleported)
        {
            StartCoroutine( ChangeTelPosCo() );           
        }
        else if (BoatOneStatics.isBoatTeleported && !isTeleported)
        {
            if (parentObj && thisPlayer)
            {
                thisPlayer.transform.parent = parentObj.transform;
            }
            StartCoroutine( ChangeTelBoatPosCo() );
        }
    }
    IEnumerator ChangeTelBoatPosCo()
    {
        if (thisPlayer)
        {
            yield return new WaitForSeconds( 2f );
            thisPlayer.transform.position = new Vector3( thisPlayer.transform.position.x , 3f , thisPlayer.transform.position.z );
        }
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
          BoatOneStatics.isBoatTeleported = true;
        }
    }
    public void PlayerTeleportBoatExit()
    {
        if (thisPlayer)
        {
          BoatOneStatics.isBoatTeleported = false;
        }
    }

}
