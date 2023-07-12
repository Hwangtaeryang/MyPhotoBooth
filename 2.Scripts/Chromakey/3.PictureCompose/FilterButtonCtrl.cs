using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class FilterButtonCtrl : MonoBehaviour
{
    public int index = 0;

    Volume volume;
    ColorLookup colorlookup;


    void Start()
    {
        for (int i = 0; i < FilterCreation.instance.filterImgMaxIndex; i++)
        {
            if (gameObject.name.Equals("Button " + (1 + i).ToString()))
                index = i;
        }
        volume = GameObject.Find("UICamera").GetComponent<Volume>();
    }


    public void ButtonClickOn()
    {
        GameManager.instance.SFXSound("ClickSound");
        volume.profile.TryGet<ColorLookup>(out colorlookup);
        colorlookup.texture.value = FilterCreation.instance.FilterChoiceViewShow(index);
        FilterCreation.instance.CheckImageView(index);
    }

}
