using System.ComponentModel;
using UnityEngine;

public class TurnOffEngine : MonoBehaviour
{
    public GameObject thisBoat;
    [DefaultValue(false)]
    public static bool isStoped { get; set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (thisBoat)
            {
                isStoped = true;
            }
        }
    }
}
