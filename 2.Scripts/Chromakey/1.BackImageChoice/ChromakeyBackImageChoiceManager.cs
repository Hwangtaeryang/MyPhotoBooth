using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChromakeyBackImageChoiceManager : MonoBehaviour
{

    public Transform makeParentPos; //백배경 생성될 위치
    public GameObject copyPrefab;
    GameObject copyObj;

    public static int backImgIndex;

    FileInfo[] backImgData;
    string backImgPath;
    int backImgMaxNum;



    void Start()
    {
        backImgPath = Application.persistentDataPath + "/ChromakeyBackImage";
        DirectoryInfo di = new DirectoryInfo(backImgPath);
        backImgData = di.GetFiles("*.png");
        backImgMaxNum = backImgData.Length;

        //백배경 갯수만큼 생성
        for(int i = 0; i < backImgMaxNum; i++)
        {
            copyObj = Instantiate(copyPrefab, makeParentPos);
            byte[] backImgByte =
                File.ReadAllBytes(Application.persistentDataPath + "/ChromakeyBackImage/" + backImgData[i].Name);
            Texture2D backImgTexture = null;
            backImgTexture = new Texture2D(0, 0);
            backImgTexture.LoadImage(backImgByte);
            copyObj.transform.GetChild(0).GetComponent<RawImage>().texture = backImgTexture;
        }
    }

    
    public void BackImageChoiceSaveButtonOn()
    {
        GameManager.instance.SFXSound("ClickSound");
        PlayerPrefs.SetString("MyPhoto_ChromakeyBack", backImgData[backImgIndex].Name);
        //SceneManager.LoadScene("1_2_TakePicture");
    }
}
