using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NavMenuElementGO : MonoBehaviour
{

    public Toggle button;
    public UIManager.Screens screenToDisplay;
    public UnityEvent<UIManager.Screens> displayScreenEvent;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Toggle>();
        button.onValueChanged.AddListener(delegate { DisplayScreen(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayScreen()
    {
        if (button.isOn)
        {
            displayScreenEvent.Invoke(screenToDisplay);
        }
    }

    public void DisableButton(){
        button.isOn = false;
    }

}
