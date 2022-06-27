using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomenputField : ISelectHandler
{

    public bool buttonSelected = false;

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("button 1 selected" + eventData.currentInputModule.name);
        buttonSelected = true;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        buttonSelected = false;
        Debug.Log("button 1 deselected");
    }
}
