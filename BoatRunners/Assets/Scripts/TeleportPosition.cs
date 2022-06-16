using System.Collections;
using UnityEngine;

public class TeleportPosition : MonoBehaviour
{
    [SerializeField]
    public GameObject thisPlayer;
    private bool isTeleported = false;
    private bool isBoatTeleported = false;
    
    private bool processTel = false;
    private void FixedUpdate()
    {
        if (isTeleported && !isBoatTeleported)
        {
            StartCoroutine( ChangeTelPosCo() );           
        }
        else if (isBoatTeleported && !isTeleported)
        {
            StartCoroutine( ChangeTelBoatPosCo() );
        }
        //if (thisPlayer)
        //{
        //    if(thisPlayer.transform.position.y < 4 & !isBoatTeleported & !isTeleported)
        //        thisPlayer.transform.position = new Vector3( thisPlayer.transform.position.x , 3.7f , thisPlayer.transform.position.z );
        //}
    }
    IEnumerator ChangeTelBoatPosCo()
    {
        yield return new WaitForSeconds( 2f );
        thisPlayer.transform.position = new Vector3( thisPlayer.transform.position.x , 3f , thisPlayer.transform.position.z );
        Debug.Log( thisPlayer.transform.position );
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
