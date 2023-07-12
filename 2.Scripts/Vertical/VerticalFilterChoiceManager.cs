using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class VerticalFilterChoiceManager : MonoBehaviour
{
    public RawImage uiRawImg;


    void Start()
    {
        GetUI_Image();
    }

    
    void GetUI_Image()
    {
        byte[] vertiImgByte =
            File.ReadAllBytes(Application.persistentDataPath + "/VertBasicPictureShot/BasicPicture.png");
        Texture2D vertiTexture = null;
        vertiTexture = new Texture2D(0, 0);
        vertiTexture.LoadImage(vertiImgByte);

        uiRawImg.texture = vertiTexture;
    }
}
