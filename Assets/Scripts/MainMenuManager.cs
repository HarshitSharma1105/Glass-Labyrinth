using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject playUI;
    // Start is called before the first frame update
    void Start()
    {
       playUI.SetActive(false); 
    }

    public void OnPlayButtonClicked()
    {
        playUI.SetActive(true); 
    }
}
