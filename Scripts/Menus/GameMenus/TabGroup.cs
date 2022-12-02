using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> myTabButtons;
   
    [SerializeField] private TabButton selectedTab;
    [SerializeField] private List<GameObject> objectsToSwap;

    public void Subscribe(TabButton button)
    {
        if (myTabButtons == null)
        {
            myTabButtons = new List<TabButton>();
        }

        myTabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        if (selectedTab == null || button != selectedTab)
        {
        }
    }

    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Disalect();
        }

        selectedTab = button;

        selectedTab.Selecte();
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; ++i)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void OnTabExit(TabButton button)
    {
    }

    public void ResetTabs()
    {
        foreach (TabButton button in myTabButtons)
        {
            if (selectedTab != null && button == selectedTab)
            {
                continue;
            }
        }
    }
}