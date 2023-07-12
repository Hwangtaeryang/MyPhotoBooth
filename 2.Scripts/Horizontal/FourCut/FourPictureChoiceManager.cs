using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FourPictureChoiceManager : MonoBehaviour
{
    public static FourPictureChoiceManager instance { get; private set; }

    public RawImage[] togglePicture;
    public Toggle[] toggles;
    public Button nextBtn;

    FileInfo[] pictureData;
    byte[] pictureByte;

    public int checkCount;



    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else instance = this;
    }

    private void Start()
    {
        nextBtn.interactable = false;
        MyPitureCreation();
    }

    void MyPitureCreation()
    {
        string picturePath = Application.persistentDataPath + "/FourCutPicture";

        DirectoryInfo di = new DirectoryInfo(picturePath);
        pictureData = di.GetFiles("*.png");
        
        for(int i = 0; i < togglePicture.Length; i++)
        {
            pictureByte = File.ReadAllBytes(Application.persistentDataPath + "/FourCutPicture/" +
                pictureData[i].Name);

            Texture2D pictureTexture = null;
            pictureTexture = new Texture2D(0, 0);
            pictureTexture.LoadImage(pictureByte);

            togglePicture[i].texture = pictureTexture;
        }
    }

    public void ToggleCheck()
    {
        if(checkCount >= 4)
        {
            foreach(var t in toggles)
            {
                if (t.isOn.Equals(false))
                    t.interactable = false;
            }
            nextBtn.interactable = true;
        }
        else
        {
            nextBtn.interactable = false;
            foreach(var t in toggles)
            {
                if (t.isOn.Equals(false))
                    t.interactable = true;
            }
        }
    }

    public void PictrueChoiceNameSave()
    {
        int num = 0;

        for(int i = 0; i < toggles.Length; i++)
        {
            if(toggles[i].isOn.Equals(true))
            {
                num++;
                PlayerPrefs.SetString("MyPhoto_PictureCheckName" + num,
                    "FourCutPicture" + (i + 1).ToString());
            }
        }
    }

}
