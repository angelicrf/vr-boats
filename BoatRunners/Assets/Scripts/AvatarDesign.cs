using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarDesign : MonoBehaviour
{
    //private Avatar avatar;
    public List<Sprite> avtSprites;
    public Sprite avtFrame;
    public GameObject frameModel;
    public GameObject avatarsImg;
    public GameObject avatarCanvas;
    public GameObject avatarReviews;
    public GameObject canvAvtImg;
    public GameObject canvAvtText;
    public GameObject avatarsCanvas;

    public GameObject rvTextOne;
    public GameObject rvTextTwo;
    public GameObject rvTextThree;
    public GameObject rvTextFour;
    public GameObject rvTextFive;

    private GameObject emptyObj;
    private GameObject emptyFrame;
    private float xOrig = -17f;
    private float yOrig = 8.2f;
    private float zOrig = -20f;

    private float xFOrig;
    private float yFOrig;
    //= 8.28f;
    private float zFOrig;
    //= -19.899f;
    private bool isAvtClicked = false;
    private bool isRvClicked = false;
    private void Start()
    {

        if (frameModel)
        {
            xFOrig = frameModel.transform.position.x;
            yFOrig = frameModel.transform.position.y;
            zFOrig = frameModel.transform.position.z;
        }
        if (avtSprites.Count > 0)
        {
            for (int i = 1; i < 7; i++)
            {
                if (avatarsImg)
                {
                    emptyObj = new GameObject($"avtImage{i}");
                    emptyFrame = new GameObject($"avtFrame{i}");
                    emptyObj.AddComponent<Button>();
                    emptyObj.AddComponent<Image>().sprite = avtSprites[i - 1];
                    emptyObj.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 180);
                    emptyFrame.AddComponent<SpriteRenderer>().sprite = avtFrame;
                    emptyObj.transform.localScale = new Vector3(0.02f, 0.025f, 0.01f);
                    emptyFrame.transform.localScale = new Vector3(0.59f, 0.75f, 0f);
                    if (i % 2 == 0)
                    {
                        emptyObj.transform.position = new Vector3(xOrig - 8f, yOrig, zOrig);
                        emptyFrame.transform.position = new Vector3(xFOrig - 8f, yFOrig, zFOrig);
                        xOrig = -17f;
                        yOrig -= 6f;
                        xFOrig = -17.2f;
                        yFOrig -= 6f;
                    }
                    else
                    {
                        emptyObj.transform.position = new Vector3(xOrig, yOrig, zOrig);
                        emptyFrame.transform.position = new Vector3(xFOrig, yFOrig, zFOrig);
                    }
                    emptyObj.transform.SetParent(avatarsImg.transform);
                    emptyFrame.transform.SetParent(emptyObj.transform);
                    switch (i)
                    {
                        case 1:
                            //avatar = new Avatar(i, "Matt", "Recommened Driver", avtSprites[i-1], new List<string>());
                            //DupAvatar.dupAvatrs.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(1); });
                            break;
                        case 2:
                            //avatar = new Avatar(i,"Robert", "High Skilled Driver", avtSprites[i-1], new List<string>());
                            //DupAvatar.dupAvatrs.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(2); });
                            break;
                        case 3:
                            //avatar = new Avatar(i,"Dave", "Professional Driver", avtSprites[i-1], new List<string>());
                            //DupAvatar.dupAvatrs.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(3); });
                            break;
                        case 4:
                            //avatar = new Avatar(i,"Bryan", "Experienced Driver", avtSprites[i-1], new List<string>());
                            //DupAvatar.dupAvatrs.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(4); });
                            break;
                        case 5:
                            //avatar = new Avatar(i,"Lisa", "Trusted Driver", avtSprites[i-1], new List<string>());
                            //DupAvatar.dupAvatrs.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(5); });
                            break;
                        case 6:
                            //avatar = new Avatar(i,"Tanya", "Safe Driver", avtSprites[i-1], new List<string>());
                            //DupAvatar.dupAvatrs.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(6); });
                            break;
                    }
                }

            }
        }
    }
    public void OnClickImg(int thisId)
    {
        isAvtClicked = !isAvtClicked;
        if (avatarCanvas && isAvtClicked)
        {
            avatarCanvas.SetActive(true);
            for (int i = 0; i < DupAvatar.avatarsList.Count; i++)
            {
                if (canvAvtImg && canvAvtText && DupAvatar.avatarsList[i].AvatarId == thisId)
                {
                    DupAvatar.avtCurrentId = thisId;
                    i = thisId -1;
                    DupAvatar.avatarsList[i].AvatarSprite = avtSprites[i];
                    canvAvtText.GetComponent<Text>().text = DupAvatar.avatarsList[i].AvatarDesc;
                    canvAvtImg.GetComponent<Image>().sprite = DupAvatar.avatarsList[i].AvatarSprite;
                    break;
                }
            }
        }
        else if (!isAvtClicked)
        {
            avatarCanvas.SetActive(false);
        }
    }
    public void AvatarImageClick()
    {
        isRvClicked = !isRvClicked;
        if (isRvClicked)
        {
            if (avatarsCanvas)
            {
                avatarsCanvas.SetActive(false);
                if (avatarReviews)
                {
                    avatarReviews.SetActive(true);
                    if (rvTextOne && rvTextTwo && rvTextThree && rvTextFour && rvTextFive)
                    {
                        //Debug.Log(DupAvatar.avatarsList.Count);
                        for (int i = 0; i < 6; i++)
                        {
                            if (DupAvatar.avtCurrentId == 1)
                            {
                                i = 0;
                            }
                            else if (DupAvatar.avtCurrentId == 2)
                            {
                                i = 1;
                            }
                            else if (DupAvatar.avtCurrentId == 3)
                            {
                                i = 3;
                            }
                            else if (DupAvatar.avtCurrentId == 4)
                            {
                                i = 4;
                            }
                            else if (DupAvatar.avtCurrentId == 5)
                            {
                                i = 5;
                            }
                            rvTextOne.GetComponent<Text>().text = $"{DupAvatar.avatarsList[i].AvatarId} Comment: {DupAvatar.avatarsList[i].AvatarName} is " + DupAvatar.avatarsList[i].allCommentTest[0];
                            rvTextTwo.GetComponent<Text>().text = $"{DupAvatar.avatarsList[i].AvatarId} Comment: {DupAvatar.avatarsList[i].AvatarName} is " + DupAvatar.avatarsList[i].allCommentTest[1];
                            rvTextThree.GetComponent<Text>().text = $"{DupAvatar.avatarsList[i].AvatarId} Comment: {DupAvatar.avatarsList[i].AvatarName}" + DupAvatar.avatarsList[i].allCommentTest[2];
                            rvTextFour.GetComponent<Text>().text = $"{DupAvatar.avatarsList[i].AvatarId} Comment: {DupAvatar.avatarsList[i].AvatarName}" + DupAvatar.avatarsList[i].allCommentTest[3];
                            rvTextFive.GetComponent<Text>().text = $"{DupAvatar.avatarsList[i].AvatarId} Comment: {DupAvatar.avatarsList[i].AvatarName}" + DupAvatar.avatarsList[i].allCommentTest[4];
                            break;
                        }
                    }

                }
                for (int i = 1; i < 7; i++)
                {
                    if (gameObject.transform.Find($"avtImage{i}") && gameObject.transform.Find($"avtFrame{i}"))
                    {
                        gameObject.transform.Find($"avtImage{i}").transform.gameObject.SetActive(false);
                        gameObject.transform.Find($"avtFrame{i}").transform.gameObject.SetActive(false);
                    }
                }
               
            }
        }
        else
        {
            if (avatarsCanvas)
            {
                avatarsCanvas.SetActive(true);
                if (avatarReviews)
                {
                    avatarReviews.SetActive(false);
                }
                for (int i = 1; i < 7; i++)
                {
                    if (gameObject.transform.Find($"avtImage{i}") && gameObject.transform.Find($"avtFrame{i}"))
                    {
                        gameObject.transform.Find($"avtImage{i}").transform.gameObject.SetActive(true);
                        gameObject.transform.Find($"avtFrame{i}").transform.gameObject.SetActive(true);
                    }
                }
            }
            gameObject.SetActive(false);

        }
    }
    public void ClothesIcon()
    {
        Debug.Log("btnCloth..");
    }
    public void AccessoriesBtn()
    {
        Debug.Log("btnAccessories..");
    }
    public void ButtomBtn()
    {
        Debug.Log("btnButtom..");
    }
    public void TopBtn()
    {
        Debug.Log("btnTop..");
    }
    public void ShoesBtn()
    {
        Debug.Log("btnShoes..");
    }
  
}
