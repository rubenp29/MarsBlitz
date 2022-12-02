using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
