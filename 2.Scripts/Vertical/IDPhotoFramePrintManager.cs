using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IDPhotoFramePrintManager : MonoBehaviour
{
    public GameObject rawImg_3x4;
    public GameObject rawImg_35x45;
    public GameObject canvar_3x4;
    public GameObject canvar_35x45;
    public RawImage[] view_3x4RawImgs;
    public RawImage[] view_35x45RawImgs;
    public GameObject camera_3x4;
    public GameObject camera_35x45;
    public Button printBtn;
    public GameObject printingTimer;
    public TextMeshProUGUI waitTimerText;


    string composeImgPath;
    int currTime = 30;


    void Start()
    {
        composeImgPath = Application.persistentDataPath + "/ID_FilterComposePicture/ID_FilterPicture.png";
        byte[] printImgData = File.ReadAllBytes(composeImgPath);
        Texture2D printTexture = null;
        printTexture = new Texture2D(0, 0);
        printTexture.LoadImage(printImgData);

        if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
        {
            rawImg_3x4.SetActive(true);
            rawImg_35x45.SetActive(false);
            canvar_3x4.SetActive(true);
            canvar_35x45.SetActive(false);
            camera_3x4.SetActive(true);
            camera_35x45.SetActive(false);
            for (int i = 0; i < view_3x4RawImgs.Length; i++)
                view_3x4RawImgs[i].texture = printTexture;
        }   
        else if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
        {
            rawImg_3x4.SetActive(false);
            rawImg_35x45.SetActive(true);
            canvar_3x4.SetActive(false);
            canvar_35x45.SetActive(true);
            camera_3x4.SetActive(false);
            camera_35x45.SetActive(true);
            for (int i = 0; i < view_35x45RawImgs.Length; i++)
                view_35x45RawImgs[i].texture = printTexture;
        }

        StartCoroutine(PrintImageSave());
    }

    IEnumerator PrintImageSave()
    {
        yield return new WaitForSeconds(1f);

        if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
            UICameraPictrueShot.Static_UiTeakePictureShot(1600, 2400, 0);
        else if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
            UICameraPictrueShot.Static_UiTeakePictureShot(2400, 1600, 0);
    }


    public void PrintButtonOn()
    {
        GameManager.instance.SFXSound("ClickSound");

        string printImgPath = Application.persistentDataPath + "/Print/PrintPicture.png";

        string printerName = "Sinfonia CHC-S2245";
        string _rePrintPath = Regex.Replace(printImgPath, "/", "\\");
        string printFullCommand =
            "rundll32 C:\\WINDOWS\\system32\\shimgvw.dll,ImageView_PrintTo " + "\"" + _rePrintPath + "\"" + " " + "\"" + printerName + "\"";
        
        PrinterStart(printFullCommand);
    }

    void PrinterStart(string _cmd)
    {
        try
        {
            Process myProcess = new Process();
            //myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = "/c " + _cmd;
            myProcess.EnableRaisingEvents = true;
            myProcess.Start();
            myProcess.WaitForExit();

            printBtn.gameObject.SetActive(false);
            printingTimer.SetActive(true);
            printingTimer.transform.GetChild(0).transform.DORotate
                (new Vector3(0f, 0f, -360f), 2.5f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);

            StartCoroutine(PrintingWait());
        }
        catch(Exception e)
        {
            UnityEngine.Debug.Log(e);
        }
    }

    IEnumerator PrintingWait()
    {
        StartCoroutine(WaitTimer());
        yield return new WaitForSeconds(30f);
        printingTimer.SetActive(false);
    }

    IEnumerator WaitTimer()
    {
        while (currTime > 0)
        {
            yield return new WaitForSeconds(1);
            currTime -= 1;
            waitTimerText.text = currTime.ToString();
        }
    }
}
