using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KbIN : InputField
{
    public static InputField Selected;
    public override void OnSelect(BaseEventData eventData)
    {
        Debug.Log("isSelected");
        base.OnSelect(eventData);
        Selected = this;
    }
}
