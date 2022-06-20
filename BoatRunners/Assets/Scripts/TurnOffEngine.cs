using UnityEngine;

public class TurnOffEngine : MonoBehaviour
{
    public GameObject thisBoat;
    public void TurnOffEngineBoatOne()
    {
        if (thisBoat)
        {
            Debug.Log( "stoped" );
            BoatOneStatics.isStoped = true;
        }
    }
}
