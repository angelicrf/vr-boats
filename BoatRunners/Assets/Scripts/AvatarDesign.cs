using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarDesign : MonoBehaviour
{
    private List<Avatar> avatars;
    private Avatar avatar;

    public List<Sprite> avtSprites;
    public Sprite avtFrame;
    public GameObject frameModel;
    public GameObject avatarsImg;
    public GameObject avatarCanvas;
    public GameObject canvAvtImg;
    public GameObject canvAvtText;
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
    private void Start()
    {
        avatars = new List<Avatar>();
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
                            avatar = new Avatar(i, "Matt", "Recommened Driver", avtSprites[i-1]);
                            avatars.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(1); });
                            break;
                        case 2:
                            avatar = new Avatar(i,"Robert", "High Skilled Driver", avtSprites[i-1]);
                            avatars.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(2); });
                            break;
                        case 3:
                            avatar = new Avatar(i,"Dave", "Professional Driver", avtSprites[i-1]);
                            avatars.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(3); });
                            break;
                        case 4:
                            avatar = new Avatar(i,"Bryan", "Experienced Driver", avtSprites[i-1]);
                            avatars.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(4); });
                            break;
                        case 5:
                            avatar = new Avatar(i,"Lisa", "Trusted Driver", avtSprites[i-1]);
                            avatars.Add(avatar);
                            emptyObj.GetComponent<Button>().onClick.AddListener(delegate { OnClickImg(5); });
                            break;
                        case 6:
                            avatar = new Avatar(i,"Tanya", "Safe Driver", avtSprites[i-1]);
                            avatars.Add(avatar);
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
            for (int i = 0; i < avatars.Count; i++)
            {
                if (avatars.Count > 0 && canvAvtImg && canvAvtText && avatars[i].AvatarId == thisId)
                {
                    canvAvtText.GetComponent<Text>().text = avatars[i].AvatarDesc;
                    canvAvtImg.GetComponent<Image>().sprite = avatars[i].AvatarSprite;
                }
            }
        }
        else if (!isAvtClicked)
        {
            avatarCanvas.SetActive(false);
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
