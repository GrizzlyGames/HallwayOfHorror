using UnityEngine;
using System.Collections;

public class LightSwitch_Script : MonoBehaviour {

    public GameObject lightContainer;

    public void setLights()
    {
        Debug.Log("Set Lights called");
        if (lightContainer.activeInHierarchy == true)
        {
            Debug.Log("Lights Off");
            lightContainer.SetActive(false);
        }
        else
        {
            Debug.Log("Lights On");
            lightContainer.SetActive(true);
        }
    }
}
