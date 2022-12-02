using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public void Settings()
    {
        GameManager.Instance.LoadSettings();
    }
}