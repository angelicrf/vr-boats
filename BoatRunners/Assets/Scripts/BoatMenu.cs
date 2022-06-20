using UnityEngine;

public class BoatMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject displayMenu;
    public GameObject gpsMap;
    public void StartBoatSystem()
    {
        mainMenu.SetActive( false );
        displayMenu.SetActive( true );
    }
    public void StartBoatGPSSystem()
    {
        displayMenu.SetActive( false );
        gpsMap.SetActive( true );
    }

}
