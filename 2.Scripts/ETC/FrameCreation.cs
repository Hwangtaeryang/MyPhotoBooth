using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FrameCreation : MonoBehaviour
{
    public static FrameCreation instance { get; private set; }

    public Transform makeParentPos;
    public GameObject copyPrefab;
    GameObject copyObj;

    string framePath;
    FileInfo[] frameData;
    byte[] frameByte;

    public int frameMaxIndex = 0;


    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else instance = this;
    }


    void Start()
    {
        if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Horizontal"))
            frameMaxIndex = GameManager.instance.frameMaxIndex_H;
        else if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Vertical"))
            frameMaxIndex = GameManager.instance.frameMaxIndex_V;
        else if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("FourCut"))
            frameMaxIndex = GameManager.instance.frameMaxIndex_F;

        FrameButtonCreation();
    }

    
    void FrameButtonCreation()
    {
        //framePath = Application.persistentDataPath + "/Frame/" + PlayerPrefs.GetString("MyPhoto_PictureMode");

        //DirectoryInfo di = new DirectoryInfo(framePath);
        //frameData = di.GetFiles("*.png");
        //frameMaxIndex = frameData.Length;

        ////필터 갯수에 맞게 생성하기
        //for(int i = 0; i < frameMaxIndex; i++)
        //{
        //    copyObj = Instantiate(copyPrefab, makeParentPos);
        //    byte[] frameByte = File.ReadAllBytes(Application.persistentDataPath +
        //        "/Frame/" + PlayerPrefs.GetString("MyPhoto_PictureMode") + "/" + frameData[i].Name);
        //    Texture2D frameTexture = null;
        //    frameTexture = new Texture2D(0, 0);
        //    frameTexture.LoadImage(frameByte);

        //    copyObj.GetComponent<Image>().sprite =
        //        Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0, 0));
        //    copyObj.name = "Button " + (i + 1).ToString();

        //    if(PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Horizontal"))
        //    {
        //        if (i.Equals(0))
        //            Hori_FrameChoiceManager.instance.FrameShow
        //                (Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0, 0)));
        //    }
        //    else if(PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Vertical"))
        //    {
        //        if (i.Equals(0))
        //            VerticalFrameChoiceManager.instance.FrameShow
        //                (Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0, 0)));
        //    }
        //    else if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("FourCut"))
        //    {
        //        if (i.Equals(0))
        //            FourPictureFrameManager.instance.FrameShow
        //                (Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0, 0)));
        //    }
        //}

        for(int i = 0; i < frameMaxIndex; i++)
        {
            copyObj = Instantiate(copyPrefab, makeParentPos);
            

            if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Horizontal"))
            {
                copyObj.GetComponent<Image>().sprite = GameManager.instance.spriteList_H[i];
                copyObj.name = "Button " + (i + 1).ToString();
                
                if(i.Equals(0))
                    Hori_FrameChoiceManager.instance.FrameShow(GameManager.instance.spriteList_H[i]);
            }
            else if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Vertical"))
            {
                copyObj.GetComponent<Image>().sprite = GameManager.instance.spriteList_V[i];
                copyObj.name = "Button " + (i + 1).ToString();

                if(i.Equals(0))
                    VerticalFrameChoiceManager.instance.FrameShow(GameManager.instance.spriteList_V[i]);
            }
            else if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("FourCut"))
            {
                copyObj.GetComponent<Image>().sprite = GameManager.instance.spriteList_F[i];
                copyObj.name = "Button " + (i + 1).ToString();

                if(i.Equals(0))
                    FourPictureFrameManager.instance.FrameShow(GameManager.instance.spriteList_F[i]);
            }
        }
    }

    public void CheckImageView(int _index)
    {
        for(int i = 0; i < makeParentPos.childCount; i++)
        {
            makeParentPos.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }

        makeParentPos.GetChild(_index).transform.GetChild(0).gameObject.SetActive(true);
        FrameShow(_index);
    }

    void FrameShow(int _index)
    {
        //byte[] frameByte = File.ReadAllBytes(Application.persistentDataPath +
        //        "/Frame/" + PlayerPrefs.GetString("MyPhoto_PictureMode") + "/" + frameData[_index].Name);
        //Texture2D frameTexture = null;
        //frameTexture = new Texture2D(0, 0);
        //frameTexture.LoadImage(frameByte);

        if(PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Horizontal"))
        {
            //Hori_FrameChoiceManager.instance.FrameShow
            //       (Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0, 0)));
            Hori_FrameChoiceManager.instance.FrameShow(GameManager.instance.spriteList_H[_index]);
        }
        else if(PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("Vertical"))
        {
            //VerticalFrameChoiceManager.instance.FrameShow
            //    (Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0, 0)));
            VerticalFrameChoiceManager.instance.FrameShow(GameManager.instance.spriteList_V[_index]);

        }
        else if (PlayerPrefs.GetString("MyPhoto_PictureMode").Equals("FourCut"))
        {
            //FourPictureFrameManager.instance.FrameShow
            //    (Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0, 0)));
            FourPictureFrameManager.instance.FrameShow(GameManager.instance.spriteList_F[_index]);
        }
    }
}
