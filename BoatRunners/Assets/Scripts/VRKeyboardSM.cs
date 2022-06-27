using System;
using UnityEngine;
using UnityEngine.UI;

public static class VRKeyboardSM
{
    public static InputField inputField;

    public static string Text
    {
        get
        {
            return inputField.text;
        }
        set
        {
            inputField.text = value;
        }
    }
  
    public static void SendBackspace()
    {
        if (Text.Length > 0)
        {
            inputField.ProcessEvent(Event.KeyboardEvent("backspace"));
            inputField.ForceLabelUpdate();
        }
    }

    public static void SendKey(string value)
    {
        Event fakeEvent;
        switch (value)
        {
            case "&":
                fakeEvent = Event.KeyboardEvent("a");
                fakeEvent.keyCode = KeyCode.Ampersand;
                fakeEvent.character = value[0];
                break;
            case "^":
                fakeEvent = Event.KeyboardEvent("a");
                fakeEvent.keyCode = KeyCode.Caret;
                fakeEvent.character = value[0];
                break;
            case "%":
                fakeEvent = Event.KeyboardEvent("a");
                fakeEvent.keyCode = KeyCode.Percent;
                fakeEvent.character = value[0];
                break;
            case "#":
                fakeEvent = Event.KeyboardEvent("a");
                fakeEvent.keyCode = KeyCode.Hash;
                fakeEvent.character = value[0];
                break;
            default:
                if (value.Length != 1)
                {
                    Debug.LogError("Ignoring spurious multi-character key value: " + value);
                    return;
                }
                fakeEvent = Event.KeyboardEvent(value);
                char keyChar = value[0];
                fakeEvent.character = keyChar;
                if (Char.IsUpper(keyChar))
                {
                    fakeEvent.modifiers |= EventModifiers.Shift;
                }
                Debug.Log(fakeEvent.character);
                break;
        }
        inputField.ProcessEvent(fakeEvent);
        inputField.ForceLabelUpdate();
    }
}
