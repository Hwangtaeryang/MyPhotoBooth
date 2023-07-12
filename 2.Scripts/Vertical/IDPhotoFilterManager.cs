using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class IDPhotoFilterManager : MonoBehaviour
{
    public GameObject canvar_3x4;
    public GameObject canvar_35x45;
    public GameObject camera_3x4;
    public GameObject camera_35x45;
    public RawImage ui_3x4RawImg;
    public RawImage ui_35x45RawImg;


    string path;


    void Start()
    {
        if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
        {
            canvar_3x4.SetActive(true);
            canvar_35x45.SetActive(false);
            camera_3x4.SetActive(true);
            camera_35x45.SetActive(false);
            ui_3x4RawImg.gameObject.SetActive(true);
            ui_35x45RawImg.gameObject.SetActive(false);

            path = Application.persistentDataPath + "/ID_Photo/3x4Photo/3x4Picture.png";
        }
        else if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
        {
            canvar_3x4.SetActive(false);
            canvar_35x45.SetActive(true);
            camera_3x4.SetActive(false);
            camera_35x45.SetActive(true);
            ui_3x4RawImg.gameObject.SetActive(false);
            ui_35x45RawImg.gameObject.SetActive(true);

            path = Application.persistentDataPath + "/ID_Photo/35x45Photo/35x45Pictrue.png";
        }
            

        GetUI_Image();
    }

    void GetUI_Image()
    {
        byte[] idImgBtye = File.ReadAllBytes(path);
        Texture2D idTexture = null;
        idTexture = new Texture2D(0, 0);
        idTexture.LoadImage(idImgBtye);

        if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
            ui_3x4RawImg.texture = idTexture;
        else if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
            ui_35x45RawImg.texture = idTexture;
    }
}
