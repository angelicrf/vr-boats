using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverDriveAnim : MonoBehaviour
{
    public GameObject walkAnim;
    public GameObject thisSeat;
    public GameObject boatMenu;
    private bool isInputDevices = false;
    private bool isEntered = false;
    public GameObject avtCap;
    public GameObject avtSG;
    public GameObject avtShoes;
    public GameObject avtShirts;
    public GameObject avtShorts;
    public List<Material> shoesMts;
    public List<Material> shortsMts;
    public List<Material> shirtsMts;
    private void Start()
    {
        if (!BoatOneStatics.isDrOptionsAuto)
        {
            if (shoesMts.Count > 0 && shirtsMts.Count > 0 && shirtsMts.Count > 0)
            {
                DupAvatar.dupMTShorts = shortsMts;
                DupAvatar.dupMTShirts = shirtsMts;
                DupAvatar.dupMTShoes = shoesMts;
            }
        }
    }
    private void FixedUpdate()
    {
        if (BoatOneStatics.isTeleportCompleted)
            
        {
            gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
            gameObject.transform.localPosition = new Vector3(thisSeat.transform.localPosition.x - 0.1f, -1.24f, thisSeat.transform.localPosition.z + 0.65f);
            if (avtSG && avtCap && avtShirts && avtShoes && avtShorts)
            {
                DupAvatar.CustomizeAvatar(avtCap, avtSG, avtShorts, avtShirts, avtShoes);
            }
            if (!BoatOneStatics.isBoatOneStartDrive)
            {
                if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Start"))
                {
                    if (!isEntered)
                    {
                        StartCoroutine(MakeTimeChanges());
                    }
                }
                StartCoroutine(DriverStatics.MoveToDriveAnimCo(gameObject, "isDriving", res => BoatOneStatics.isDriveBoatOne = res));
            }
            if (BoatOneStatics.isBoatOneStartDrive && !BoatOneStatics.isDriveBoatOne && BoatOneStatics.isDrOptionsAuto)
            {
                StartCoroutine(DriverStatics.MoveDriveToWalkAnimCo(gameObject, walkAnim));
            }
            if (!isInputDevices)
            {
                isInputDevices = DriverStatics.GetInputDevices();
            }
            if (isInputDevices && boatMenu)
            {
                DriverStatics.ReactivateBoatMenu(boatMenu);
            }
        }
    }
    private IEnumerator MakeTimeChanges()
    {
        gameObject.transform.localPosition = new Vector3(thisSeat.transform.localPosition.x - 0.1f, 0, thisSeat.transform.localPosition.z + 0.65f);
        yield return new WaitForSeconds(2f);
        gameObject.transform.localPosition = new Vector3(thisSeat.transform.localPosition.x - 0.1f, -1.24f, thisSeat.transform.localPosition.z + 0.65f);
        isEntered = true;
    }
   
}
