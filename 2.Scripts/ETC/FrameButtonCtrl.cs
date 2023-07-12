using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameButtonCtrl : MonoBehaviour
{
    public int index = 0;



    void Start()
    {
        for(int i = 0; i < FrameCreation.instance.frameMaxIndex; i++)
        {
            if (gameObject.name.Equals("Button " + (1 + i).ToString()))
                index = i;
        }
    }

    public void ButtonClickOn()
    {
        GameManager.instance.SFXSound("ClickSound");
        FrameCreation.instance.CheckImageView(index);
    }
}
