using UnityEngine;

public class BackUIMenu : MonoBehaviour
{
    public GameObject thisSubPanel;
    public GameObject thisMainMenu;
    public void BackToMenu()
    {
        if(thisMainMenu && thisSubPanel)
        {
            thisSubPanel.SetActive( false );
            thisMainMenu.SetActive( true );
        }
    }
 
}
