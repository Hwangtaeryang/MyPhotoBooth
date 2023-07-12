using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleCheck : MonoBehaviour
{
    public Toggle toggle;

    string toggleName;


    public void Check()
    {
        toggleName = EventSystem.current.currentSelectedGameObject.name;

        if (toggle.isOn.Equals(true))
        {
            FourPictureChoiceManager.instance.checkCount++;
        }
        else
        {
            FourPictureChoiceManager.instance.checkCount--;
        }
        FourPictureChoiceManager.instance.ToggleCheck();
    }
}
