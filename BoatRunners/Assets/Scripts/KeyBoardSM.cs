using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WindowsInput;
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
    private string testText;
    InputSimulator IS;

    void Start()
    {
        thisText = "";
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

        is1 = false; ;
        is2 = false;
        is3 = false;
        is4 = false;
        is5 = false;
        is6 = false;
        is7 = false;
        is8 = false;
        is9 = false;
        is0 = false;
        testText = "";
        isSpace = false;
        isComma = false;
        isDot = false;
        isSlash = false;
        isDash = false;
        isNumberSign = false;
        isBackSpace = false;
        thisList = new List<char>();
        IS = new InputSimulator();

        if (thisInput)
        {
            thisText = thisInput.GetComponent<InputField>().text;
            thisInt = thisInput.GetComponent<InputField>().caretPosition;

        }
        thisInput.GetComponent<InputField>().ActivateInputField();
    }

    private void LateUpdate()
    {
        //thisInput.GetComponent<InputField>().Select();
        thisInput.GetComponent<InputField>().ActivateInputField();
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "KBIN")
            {
                thisKeyboard.SetActive(true);
            } 
        }
            //if (EventSystem.current.currentSelectedGameObject != null)
            //{
            //    if (EventSystem.current.currentSelectedGameObject.name == "KBIN")
            //    {
            //        thisKeyboard.SetActive(true);
            //        prevBackSpace = thisInput.GetComponent<InputField>().caretPosition;
            //    }
            //}
            //if (prevBackSpace != 0)
            //{
            //    if (isBackSpace)
            //    {
            //        thisList.RemoveAt(prevBackSpace - 1);
            //        thisInput.GetComponent<InputField>().text = new string(thisList.ToArray());
            //        thisText = thisInput.GetComponent<InputField>().text;
            //        isBackSpace = false;
            //    }
            //}    
            if (isBackSpace)
        {
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.BACK);
            //thisList.RemoveAt(thisText.Length - 1);
            //thisInput.GetComponent<InputField>().text = new string(thisList.ToArray());
            //thisText = thisInput.GetComponent<InputField>().text;
            isBackSpace = false;
        }

    }

    private void SimulateTypedText(string text)
    {
        char[] words = text.ToCharArray();
        foreach (char word in words)
        {
            IS.Keyboard.TextEntry(word);
        }
    }
    public void BtnSpaceClick()
    {
        isSpace = true;
    }
    public void BtnBackSpaceClick()
    {
        isBackSpace = true;
    }
    public void BtnNSClick()
    {
        isNumberSign = true;
    }
    public void BtnCommaClick()
    {
        isComma = true;
    }
    public void BtnDotClick()
    {
        isDot = true;
    }
    public void BtnSlashClick()
    {
        isSlash = true;
    }
    public void BtnDasheClick()
    {
        isDash = true;
    }
    public void Btn1Click()
    {
        is1 = true;
    }
    public void Btn2Click()
    {
        is2 = true;
    }
    public void Btn3Click()
    {
        is3 = true;
    }
    public void Btn4Click()
    {
        is4 = true;
    }
    public void Btn5Click()
    {
        is5 = true;
    }
    public void Btn6Click()
    {
        is6 = true;
    }
    public void Btn7Click()
    {
        is7 = true;
    }
    public void Btn8Click()
    {
        is8 = true;
    }
    public void Btn9Click()
    {
        is9 = true;
    }
    public void Btn0Click()
    {
        is0 = true;
    }
    public void BtnAClick()
    {
        isA = true;
    }
    public void BtnBClick()
    {
        isB = true;
    }
    public void BtnCClick()
    {
        isC = true;
    }
    public void BtnDClick()
    {
        isD = true;
    }
    public void BtnEClick()
    {
        isE = true;
    }
    public void BtnFClick()
    {
        isF = true;
    }
    public void BtnGClick()
    {
        isG = true;
    }
    public void BtnHClick()
    {
        isH = true;
    }
    public void BtnIClick()
    {
        isI = true;
    }
    public void BtnKClick()
    {
        isK = true;
    }
    public void BtnJClick()
    {
        isJ = true;
    }
    public void BtnLClick()
    {
        isL = true;
    }
    public void BtnMClick()
    {
        isM = true;
    }
    public void BtnNClick()
    {
        isN = true;
    }
    public void BtnOClick()
    {
        isO = true;
    }
    public void BtnPClick()
    {
        isP = true;
    }
    public void BtnQClick()
    {
        isQ = true;
    }
    public void BtnRClick()
    {
        isR = true;
    }
    public void BtnSClick()
    {
        isS = true;
    }
    public void BtnTClick()
    {
        isT = true;
    }
    public void BtnWClick()
    {
        isW = true;
    }
    public void BtnXClick()
    {
        isX = true;
    }
    public void BtnYClick()
    {
        isY = true;
    }
    public void BtnZClick()
    {
        isZ = true;
    }
    public void BtnUClick()
    {
        isU = true;
    }
    public void BtnVClick()
    {
        isV = true;
    }
    public void AllBtnsClick()
    {
        if (isA)
        {
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_A);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            //thisChar = 'a';
            //thisList.Add(thisChar);
            isA = false;
        }
        else if (isB)
        {
            //thisChar = 'b';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_B);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isB = false;
        }
        else if (isC)
        {
            //thisChar = 'c';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_C);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isC = false;
        }
        else if (isD)
        {
            //thisChar = 'd';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_D);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isD = false;
        }
        else if (isE)
        {
            //thisChar = 'e';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_E);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isE = false;
        }
        else if (isF)
        {
            //thisChar = 'f';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_F);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isF = false;
        }
        else if (isG)
        {
            //thisChar = 'g';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_G);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isG = false;
        }
        else if (isH)
        {
            //thisChar = 'h';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_H);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isH = false;
        }
        else if (isI)
        {
            //thisChar = 'i';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_I);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isI = false;
        }
        else if (isJ)
        {
            //thisChar = 'j';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_J);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isJ = false;
        }
        else if (isK)
        {
            //thisChar = 'k';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_K);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isK = false;
        }
        else if (isL)
        {
            //thisChar = 'l';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_L);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isL = false;
        }
        else if (isM)
        {
            //thisChar = 'm';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_M);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isM = false;
        }
        else if (isN)
        {
            //thisChar = 'n';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_N);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isN = false;
        }
        else if (isO)
        {
            //thisChar = 'o';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_O);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isO = false;
        }
        else if (isP)
        {
            //thisChar = 'p';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_P);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isP = false;
        }

        else if (isQ)
        {
            //thisChar = 'q';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_Q);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isQ = false;
        }
        else if (isR)
        {
            //thisChar = 'r';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_R);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isR = false;
        }
        else if (isS)
        {
            //thisChar = 's';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_S);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isS = false;
        }
        else if (isT)
        {
            //thisChar = 't';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_T);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isT = false;
        }
        else if (isU)
        {
            //thisChar = 'u';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_U);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isU = false;
        }
        else if (isV)
        {
            //thisChar = 'v';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_V);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isV = false;
        }
        else if (isW)
        {
            //thisChar = 'w';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_W);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isW = false;
        }
        else if (isX)
        {
            //thisChar = 'x';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_X);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isX = false;
        }
        else if (isY)
        {
            //thisChar = 'y';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_Y);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isY = false;
        }
        else if (isZ)
        {
            //thisChar = 'z';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_Z);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isZ = false;
        }//numbers
        else if (is0)
        {
            //thisChar = '0';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_0);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is0 = false;
        }
        else if (is1)
        {
            //thisChar = '1';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_1);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is1 = false;
        }
        else if (is2)
        {
            //thisChar = '2';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_2);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is2 = false;
        }
        else if (is3)
        {
            //thisChar = '3';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_3);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is3 = false;
        }
        else if (is4)
        {
            //thisChar = '4';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_4);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is4 = false;
        }
        else if (is5)
        {
            //thisChar = '5';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_5);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is5 = false;
        }
        else if (is6)
        {
            //thisChar = '6';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_6);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is6 = false;
        }
        else if (is7)
        {
            //thisChar = '7';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_7);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is7 = false;
        }
        else if (is8)
        {
            //thisChar = '8';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_8);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is8 = false;
        }
        else if (is9)
        {
            //thisChar = '9';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_9);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            is9 = false;
        }
        else if (isSpace)
        {
            //thisChar = '\u0020';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isSpace = false;
        }
        else if (isComma)
        {
            //thisChar = ',';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.OEM_COMMA);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isComma = false;
        }
        else if (isDot)
        {
            //thisChar = '.';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.OEM_PERIOD);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isDot = false;
        }
        else if (isSlash)
        {
            //thisChar = '/';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DIVIDE);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isSlash = false;
        }
        else if (isDash)
        {
            //thisChar = '-';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.OEM_MINUS);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isDash = false;
        }
        else if (isNumberSign)
        {
            //thisChar = '#';
            //thisList.Add(thisChar);
            thisInput.GetComponent<InputField>().ActivateInputField();
            IS.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.SHIFT, WindowsInput.Native.VirtualKeyCode.VK_3);
            thisInput.GetComponent<InputField>().MoveTextEnd(false);
            isNumberSign = false;
        }
        //if (thisList != null && thisList.Count > 0)
        //{
        //    thisInput.GetComponent<InputField>().text = new string(thisList.ToArray());
        //    thisText = thisInput.GetComponent<InputField>().text;
        //}
    }
    public void BtnEnterClick()
    {
        BoatOneStatics.iskeyBoardUsed = true;
        thisInput.GetComponent<InputField>().ActivateInputField();
        IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
    }
    public void EndOnChange()
    {
        thisInput.GetComponent<InputField>().text = thisText;
        BoatOneStatics.iskeyBoardUsed = false;
    }
}
