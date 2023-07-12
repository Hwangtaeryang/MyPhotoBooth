using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class VerticalFrameChoiceManager : MonoBehaviour
{
    public static VerticalFrameChoiceManager instance { get; private set; }


    public RawImage uiRawImg;
    public Image frameImg;



    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else instance = this;
    }

    void Start()
    {
        GetUI_Image();
    }

    
    void GetUI_Image()
    {
        byte[] vertiImgByte =
            File.ReadAllBytes(Application.persistentDataPath + "/VertiFilterComposePicture/V_FilterPicture.png");
        Texture2D vertiTextrue = null;
        vertiTextrue = new Texture2D(0, 0);
        vertiTextrue.LoadImage(vertiImgByte);
        uiRawImg.texture = vertiTextrue;
    }

    public void FrameShow(Sprite _sprite)
    {
        frameImg.sprite = _sprite;
    }
}
