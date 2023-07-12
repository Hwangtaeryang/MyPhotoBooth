using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PictureComposeManager : MonoBehaviour
{
    public static PictureComposeManager instance { get; private set; }

    public RawImage backPictureImg;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else instance = this;
    }

    void Start()
    {
        byte[] flieByte = File.ReadAllBytes(Application.persistentDataPath + "/ChromakeyBackImage/" + 
            PlayerPrefs.GetString("MyPhoto_ChromakeyBack"));
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(flieByte);
        backPictureImg.texture = texture;

    }

}
