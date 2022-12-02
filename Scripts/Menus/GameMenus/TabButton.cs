using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TabGroup myTabGroup;
    [SerializeField] private RawImage background;
    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;
    public void OnPointerClick(PointerEventData eventData)
    {
        myTabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    { 
        myTabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myTabGroup.OnTabExit(this);
    }

    private void Start()
    {
        myTabGroup.Subscribe(this);
    }

    public void Selecte()
    {
        if (onTabSelected != null)
        {
            onTabSelected.Invoke();
        }
    }

    public void Disalect()
    {
        if (onTabDeselected != null)
        {
            onTabDeselected.Invoke();
        }
    }
}