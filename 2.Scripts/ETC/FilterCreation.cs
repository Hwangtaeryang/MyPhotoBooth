using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FilterCreation : MonoBehaviour
{
    public static FilterCreation instance { get; private set; }


    public Transform makeParentPos; //필터버튼 생성 위치
    public GameObject copyPrefab;   //복사할 원본 오브젝트
    GameObject copyObj;

    string filterImgPath;
    string filterPath;
    FileInfo[] filterImgData;   //폴더 속 필터이미지정보
    FileInfo[] filterData;  //폴더 속 필터정보

    byte[] filterImgByte;

    public int filterImgMaxIndex = 0;



    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else instance = this;
    }

    private void Start()
    {
        FilterButtonCreation();
    }

    //필터버튼 생성
    void FilterButtonCreation()
    {
        filterImgPath = Application.persistentDataPath + "/Filter/FilterButtonImage/" + 
            PlayerPrefs.GetString("MyPhoto_PictureMode");

        DirectoryInfo di = new DirectoryInfo(filterImgPath);
        filterImgData = di.GetFiles("*.png");
        filterImgMaxIndex = filterImgData.Length;

        //필터 갯수에 맞게 생성하기
        for (int i = 0; i < filterImgMaxIndex; i++)
        {
            copyObj = Instantiate(copyPrefab, makeParentPos);

            filterImgByte = File.ReadAllBytes(Application.persistentDataPath +
                "/Filter/FilterButtonImage/" + PlayerPrefs.GetString("MyPhoto_PictureMode") 
                + "/" + filterImgData[i].Name);

            Texture2D filterTextrue = null;
            filterTextrue = new Texture2D(0, 0);
            filterTextrue.LoadImage(filterImgByte);

            copyObj.GetComponent<Image>().sprite =
                Sprite.Create(filterTextrue, new Rect(0, 0, filterTextrue.width, filterTextrue.height), new Vector2(0, 0));

            copyObj.name = "Button " + (i + 1).ToString();
        }
    }

    public Texture FilterChoiceViewShow(int _index)
    {
        filterPath = Application.persistentDataPath + "/Filter/Filter";
        DirectoryInfo di = new DirectoryInfo(filterPath);
        filterData = di.GetFiles("*.png");

        byte[] filterByte =
            File.ReadAllBytes(Application.persistentDataPath + "/Filter/Filter/" + filterData[_index].Name);
        Texture2D filterTexture = null;
        filterTexture = new Texture2D(0, 0);
        filterTexture.LoadImage(filterByte);

        return filterTexture;
    }

    public void CheckImageView(int _index)
    {
        for (int i = 0; i < makeParentPos.childCount; i++)
        {
            makeParentPos.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
        }

        makeParentPos.GetChild(_index).transform.GetChild(1).gameObject.SetActive(true);
        PlayerPrefs.SetString("MyPhoto_FrameName", filterData[_index].Name);
    }
}
