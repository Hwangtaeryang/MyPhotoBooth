using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Hori_FilterChoiceManager : MonoBehaviour
{
    public static Hori_FilterChoiceManager instance { get; private set; }

    public RawImage uiRawImg;
    

    void Start()
    {
        GetUI_Image();
    }

    void GetUI_Image()
    {
        byte[] horiImgByte = 
            File.ReadAllBytes(Application.persistentDataPath + "/HoriBasicPictureShot/BasicPictrue.png");
        Texture2D horiTexture = null;
        horiTexture = new Texture2D(0, 0);
        horiTexture.LoadImage(horiImgByte);

        uiRawImg.texture = horiTexture;
    }

    
}
