using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHoverDestroyBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool IsHovering;

    //private variable
    private OnClick _onClick;
    private ShowInfoHover _showInfo;

    private void Awake()
    {
        _onClick = GetComponentInParent<OnClick>();
        _showInfo = GetComponentInParent<ShowInfoHover>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovering = true;
        _onClick.DestroyBtn.SetActive(true);
        _showInfo.UIHolder.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHovering = false;
        _onClick.DestroyBtn.SetActive(false);
        _showInfo.UIHolder.SetActive(false);
    }
}
