using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FourPictureFrameManager : MonoBehaviour
{
    public static FourPictureFrameManager instance { get; private set; }



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
        Get_Picture();
    }

    void Get_Picture()
    {
        byte[] pictureByte = File.ReadAllBytes(Application.persistentDataPath +
            "/FourCut_FilterComposePicture/FourCutFilterPicture.png");
        Texture2D fourTexture = null;
        fourTexture = new Texture2D(0, 0);
        fourTexture.LoadImage(pictureByte);
        uiRawImg.texture = fourTexture;
    }

    public void FrameShow(Sprite _sprite)
    {
        frameImg.sprite = _sprite;
    }


}
