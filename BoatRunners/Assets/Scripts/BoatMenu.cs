using UnityEngine;

public class BoatMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gpsMap;
    public void StartBoatSystem()
    {
        mainMenu.SetActive( false );
        gpsMap.SetActive( true );
    }
}
