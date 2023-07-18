using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHoverDestroyBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public static bool IsHovering;

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHovering = false;
    }
}
