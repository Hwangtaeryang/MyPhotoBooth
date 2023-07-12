using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FourPictureFilterManager : MonoBehaviour
{
    public RawImage[] pictureRawImg;



    void Start()
    {
        ShowPictures();
    }

    void ShowPictures()
    {
        for(int i = 0; i < pictureRawImg.Length; i++)
        {
            string picturePath = Application.persistentDataPath + "/FourCutPicture/" +
                PlayerPrefs.GetString("MyPhoto_PictureCheckName" + (i + 1).ToString()) + ".png";
            byte[] pictureByte = File.ReadAllBytes(picturePath);

            Texture2D pictureTexture = null;
            pictureTexture = new Texture2D(0, 0);
            pictureTexture.LoadImage(pictureByte);

            pictureRawImg[i].texture = pictureTexture;
        }
    }
}
