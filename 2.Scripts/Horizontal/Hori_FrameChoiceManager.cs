using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Hori_FrameChoiceManager : MonoBehaviour
{
    public static Hori_FrameChoiceManager instance { get; private set; }
    public RawImage uiRawImg;
    public Image frameImg;

    string framePath;


    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else instance = this;
    }

    void Start()
    {
        framePath = Application.persistentDataPath + "/HoriFilterComposePicture/H_FilterPicture.png";
        byte[] h_filterComposeByte = File.ReadAllBytes(framePath);
        Texture2D filterComposeTexture = null;
        filterComposeTexture = new Texture2D(0, 0);
        filterComposeTexture.LoadImage(h_filterComposeByte);

        uiRawImg.texture = filterComposeTexture;

        
    }

    public void FrameShow(Sprite _sprite)
    {
        frameImg.sprite = _sprite;
    }
}
