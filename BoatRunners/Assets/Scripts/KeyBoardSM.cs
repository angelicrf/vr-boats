using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyBoardSM : MonoBehaviour
{
    public GameObject thisKeyboard;
    public GameObject thisInput;

    private string thisText;
    private int thisInt;
    private bool isEntered;
    private bool isA;
    private bool isB;
    private bool isC;
    private bool isD;
    private bool isE;
    private bool isF;
    private bool isG;
    private bool isH;
    private bool isI;
    private bool isJ;
    private bool isK;
    private bool isL;
    private bool isM;
    private bool isN;
    private bool isO;
    private bool isP;
    private bool isQ;
    private bool isR;
    private bool isS;
    private bool isT;
    private bool isW;
    private bool isX;
    private bool isY;
    private bool isZ;
    private bool isU;
    private bool isV;

    private bool is1;
    private bool is2;
    private bool is3;
    private bool is4;
    private bool is5;
    private bool is6;
    private bool is7;
    private bool is8;
    private bool is9;
    private bool is0;
    private bool isSpace;
    private bool isComma;
    private bool isDot;
    private bool isSlash;
    private bool isDash;
    private bool isNumberSign;
    private bool isBackSpace;
    private int prevBackSpace;
    private List<char> thisList;
    char thisChar;
    void Start()
    {
        thisText = "";
        thisChar = ' ';
        thisInt = 0;
        isSpace = false;
        isB = false;
        isA = false;
        isC = false;
        isD = false;
         isE = false;
         isF = false;
         isG = false;
         isH = false;
         isI = false;
         isJ = false;
         isK = false;
         isL = false;
         isM = false;
         isN = false;
         isO = false;
         isP = false;
         isQ = false;
         isR = false;
         isS = false;
         isT = false;
         isW = false;
         isX = false;
         isY = false;
         isZ = false;
         isU = false;
         isV = false;

         is1 = false;;
         is2 = false;
         is3 = false;
         is4 = false;
         is5 = false;
         is6 = false;
         is7 = false;
         is8 = false;
         is9 = false;
         is0 = false;

         isSpace = false;
         isComma = false;
         isDot = false;
         isSlash = false;
         isDash = false;
         isNumberSign = false;
         isBackSpace = false;
         thisList = new List<char>();
        if (thisInput)
        {
            thisText = thisInput.GetComponent<InputField>().text;
            thisInt = thisInput.GetComponent<InputField>().caretPosition;
            
        }
    }
    private void FixedUpdate()
    {

        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "KBIN")
            {
                thisKeyboard.SetActive(true);
                prevBackSpace = thisInput.GetComponent<InputField>().caretPosition;
            }
        }
        if (prevBackSpace != 0)
        {
            if (isBackSpace)
            {
                thisList.RemoveAt(prevBackSpace - 1);
                thisInput.GetComponent<InputField>().text = new string(thisList.ToArray());
                thisText = thisInput.GetComponent<InputField>().text;
                isBackSpace = false;
            }
        }
    }
    public void BtnSpaceClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isSpace = true;
    }
    public void BtnBackSpaceClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isBackSpace = true;
    }
    public void BtnNSClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isNumberSign = true;
    }
    public void BtnCommaClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isComma = true;
    }
    public void BtnDotClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isDot = true;
    }
    public void BtnSlashClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isSlash = true;
    }
    public void BtnDasheClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isDash = true;
    }
    public void Btn1Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is1 = true;
    }
    public void Btn2Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is2 = true;
    }
    public void Btn3Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is3 = true;
    }
    public void Btn4Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is4 = true;
    }
    public void Btn5Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is5 = true;
    }
    public void Btn6Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is6 = true;
    }
    public void Btn7Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is7 = true;
    }
    public void Btn8Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is8 = true;
    }
    public void Btn9Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is9 = true;
    }
    public void Btn0Click()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        is0 = true;
    }
    public void BtnAClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isA = true;
    }
    public void BtnBClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isB = true;
    }
    public void BtnCClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isC = true;
    }
    public void BtnDClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isD = true;
    }
    public void BtnEClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isE = true;
    }
    public void BtnFClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isF = true;
    }
    public void BtnGClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isG = true;
    }
    public void BtnHClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isH = true;
    }
    public void BtnIClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isI = true;
    }
    public void BtnKClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isK = true;
    }
    public void BtnJClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isJ = true;
    }
    public void BtnLClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isL = true;
    }
    public void BtnMClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isM = true;
    }
    public void BtnNClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isN = true;
    }
    public void BtnOClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isO = true;
    }
    public void BtnPClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isP = true;
    }
    public void BtnQClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isQ = true;
    }
    public void BtnRClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isR = true;
    }
    public void BtnSClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isS = true;
    }
    public void BtnTClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isT = true;
    }
    public void BtnWClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isW = true;
    }
    public void BtnXClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isX = true;
    }
    public void BtnYClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isY = true;
    }
    public void BtnZClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isZ = true;
    }
    public void BtnUClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isU = true;
    }
    public void BtnVClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        isV = true;
    }
    public void AllBtnsClick()
    {
        if (isA)
        {
            thisChar = 'a';
            thisList.Add(thisChar);
            isA = false;
        }
        else if (isB)
        {
            thisChar = 'b';
            thisList.Add(thisChar);
            isB = false;
        }
        else if (isC)
        {
            thisChar = 'c';
            thisList.Add(thisChar);
            isC = false;
        }
        else if (isD)
        {
            thisChar = 'd';
            thisList.Add(thisChar);
            isD = false;
        }
        else if (isE)
        {
            thisChar = 'e';
            thisList.Add(thisChar);
            isE = false;
        }
        else if (isF)
        {
            thisChar = 'f';
            thisList.Add(thisChar);
            isF = false;
        }
        else if (isG)
        {
            thisChar = 'g';
            thisList.Add(thisChar);
            isG = false;
        }
        else if (isH)
        {
            thisChar = 'h';
            thisList.Add(thisChar);
            isH = false;
        }
        else if (isI)
        {
            thisChar = 'i';
            thisList.Add(thisChar);
            isI = false;
        }
        else if (isJ)
        {
            thisChar = 'j';
            thisList.Add(thisChar);
            isJ = false;
        }
        else if (isK)
        {
            thisChar = 'k';
            thisList.Add(thisChar);
            isK = false;
        }
        else if (isL)
        {
            thisChar = 'l';
            thisList.Add(thisChar);
            isL = false;
        }
        else if (isM)
        {
            thisChar = 'm';
            thisList.Add(thisChar);
            isM = false;
        }
        else if (isN)
        {
            thisChar = 'n';
            thisList.Add(thisChar);
            isN = false;
        }
        else if (isO)
        {
            thisChar = 'o';
            thisList.Add(thisChar);
            isO = false;
        }
        else if (isP)
        {
            thisChar = 'p';
            thisList.Add(thisChar);
            isP = false;
        }

        else if (isQ)
        {
            thisChar = 'q';
            thisList.Add(thisChar);
            isQ = false;
        }
        else if (isR)
        {
            thisChar = 'r';
            thisList.Add(thisChar);
            isR = false;
        }
        else if (isS)
        {
            thisChar = 's';
            thisList.Add(thisChar);
            isS = false;
        }
        else if (isT)
        {
            thisChar = 't';
            thisList.Add(thisChar);
            isT = false;
        }
        else if (isU)
        {
            thisChar = 'u';
            thisList.Add(thisChar);
            isU = false;
        }
        else if (isV)
        {
            thisChar = 'v';
            thisList.Add(thisChar);
            isV = false;
        }
        else if (isW)
        {
            thisChar = 'w';
            thisList.Add(thisChar);
            isW = false;
        }
        else if (isX)
        {
            thisChar = 'x';
            thisList.Add(thisChar);
            isX = false;
        }
        else if (isY)
        {
            thisChar = 'y';
            thisList.Add(thisChar);
            isY = false;
        }
        else if (isZ)
        {
            thisChar = 'z';
            thisList.Add(thisChar);
            isZ = false;
        }//numbers
        else if (is0)
        {
            thisChar = '0';
            thisList.Add(thisChar);
            is0 = false;
        }
        else if (is1)
        {
            thisChar = '1';
            thisList.Add(thisChar);
            is1 = false;
        }
        else if (is2)
        {
            thisChar = '2';
            thisList.Add(thisChar);
            is2 = false;
        }
        else if (is3)
        {
            thisChar = '3';
            thisList.Add(thisChar);
            is3 = false;
        }
        else if (is4)
        {
            thisChar = '4';
            thisList.Add(thisChar);
            is4 = false;
        }
        else if (is5)
        {
            thisChar = '5';
            thisList.Add(thisChar);
            is5 = false;
        }
        else if (is6)
        {
            thisChar = '6';
            thisList.Add(thisChar);
            is6 = false;
        }
        else if (is7)
        {
            thisChar = '7';
            thisList.Add(thisChar);
            is7 = false;
        }
        else if (is8)
        {
            thisChar = '8';
            thisList.Add(thisChar);
            is8 = false;
        }
        else if (is9)
        {
            thisChar = '9';
            thisList.Add(thisChar);
            is9 = false;
        }
        else if (isSpace)
        {
            thisChar = '\u0020';
            thisList.Add(thisChar);
            isSpace = false;
        }
        else if (isComma)
        {
            thisChar = ',';
            thisList.Add(thisChar);
            isComma = false;
        }
        else if (isDot)
        {
            thisChar = '.';
            thisList.Add(thisChar);
            isDot = false;
        }
        else if (isSlash)
        {
            thisChar = '/';
            thisList.Add(thisChar);
            isSlash = false;
        }
        else if (isDash)
        {
            thisChar = '-';
            thisList.Add(thisChar);
            isDash = false;
        }
        else if (isNumberSign)
        {
            thisChar = '#';
            thisList.Add(thisChar);
            isNumberSign = false;
        }
        if (thisList != null && thisList.Count > 0)
        {
            thisInput.GetComponent<InputField>().text = new string(thisList.ToArray());
            thisText = thisInput.GetComponent<InputField>().text;
        }
    }
    public void BtnEnterClick()
    {
       thisInput.GetComponent<InputField>().Select();
    }
    public void EndOnChange()
    {
        thisInput.GetComponent<InputField>().text = thisText;
    }
}
