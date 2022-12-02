using System;
using UnityEngine;

public class ButtonMainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.visible = true;
    }

    public void LoadMainMenu()
    {
        
        GameManager.Instance.LoadMainMenu();
    }    
}
