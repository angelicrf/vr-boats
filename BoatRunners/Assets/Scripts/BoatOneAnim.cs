using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class BoatOneAnim : MonoBehaviour
{
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;
    public GameObject targetObject5;
    public GameObject targetObject6;
    public GameObject targetObject7;
    private float speed = 1.5f;
    [DefaultValue(false)]
    private bool isStoppedOne { get; set; }

    [DefaultValue(false)]
    private bool isStoppedTwo { get; set; }
    [DefaultValue(false)]
    private bool isStoppedThree { get; set; }

    [DefaultValue(false)]
    private bool isStoppedFour { get; set; }

    [DefaultValue(false)]
    private bool isStoppedFive { get; set; }
    [DefaultValue(false)]
    private bool isStoppedSix { get; set; }
    [DefaultValue(false)]
    private bool isStoppedSeven { get; set; }
    private bool isFirstTime = false;
    public void ReduceAnimSpeed()
    {
        gameObject.GetComponent<Animator>().playbackTime = 0.2f;
            //speed = 0.35f;
    }
    private void FixedUpdate()
    {
        if (!isStoppedOne)
        {
            BoatMovePath(targetObject1,  0, 1);
        }
        else if (isStoppedTwo)
        {
            BoatMovePath(targetObject2, 1, 0);
        }
        else if (isStoppedThree)
        {
            BoatMovePath(targetObject3,  0, -1);
        }
        else if (isStoppedFour)
        {
            BoatMovePath(targetObject4, 1, -1);
        }
        else if (isStoppedFive)
        {
            BoatMovePath(targetObject5, -1, -1);
        }
        else if (isStoppedSix)
        {
           BoatMovePath(targetObject6, 0, 1);
        }
        else if (isStoppedSeven)
        {
          BoatMovePath(targetObject7, -1, 0);
        }

    }
    private void BoatMovePath(GameObject thisobj, float thisX, float thisY)
    {
        if (thisobj)
        {
            if (BoatOneStatics.isDriveBoatOne)
            {
                var speedST = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, thisobj.transform.position, speedST);

                if (Vector3.Distance(transform.position, thisobj.transform.position) < 0.001f)
                {
                    if (!gameObject.GetComponent<Animator>().enabled)
                    {
                        gameObject.GetComponent<Animator>().enabled = true;
                        if (gameObject.GetComponent<Animator>().enabled && !gameObject.GetComponent<Animator>().GetBool("isBtDrive"))
                        {
                            gameObject.GetComponent<Animator>().SetBool("isBtDrive", true);
                        }
                    }
                    else if (gameObject.GetComponent<Animator>().enabled && gameObject.GetComponent<Animator>().GetBool("isBtDrive"))
                    {
                        gameObject.GetComponent<Animator>().SetFloat("VelocityX", thisX);
                        gameObject.GetComponent<Animator>().SetFloat("VelocityY", thisY);
                        if (gameObject.GetComponent<Animator>().GetBool("isBtDrive") && gameObject.GetComponent<Animator>().GetFloat("VelocityX") == thisX && gameObject.GetComponent<Animator>().GetFloat("VelocityY") == thisY)
                        {
                            if (!isStoppedOne && !isStoppedTwo)
                            {
                                isStoppedOne = true;
                                isStoppedTwo = true;
                            }
                            else if (isStoppedTwo && !isStoppedThree)
                            {
                                isStoppedTwo = false;
                                isStoppedThree = true;
                            }

                            else if (isStoppedThree && !isStoppedFour)
                            {
                                isStoppedThree = false;
                                isStoppedFour = true;
                            }
                            else if (isStoppedFour && !isStoppedFive)
                            {
                                isStoppedFour = false;
                                isStoppedFive = true;
                            }
                            else if (isStoppedFive && !isStoppedSix)
                            {
                                isStoppedFive = false;
                                isStoppedSix = true;
                            }
                            else if (isStoppedSix && !isStoppedSeven)
                            {
                                isStoppedSix = false;
                                isStoppedSeven = true;
                                //
                                BoatOneStatics.isDriveBoatOne = false;
                            }

                        }

                    }

                }
            }
        }
    }

}
