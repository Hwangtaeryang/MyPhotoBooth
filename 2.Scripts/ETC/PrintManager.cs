using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


//https://stackoverflow.com/questions/49188307/how-to-direct-printing-of-photo-or-text-using-unity-without-preview
public class PrintManager : MonoBehaviour
{
    public RawImage viewRawImg;
    public Button printBtn;
    public GameObject printingTimer;
    public TextMeshProUGUI waitTimerText;

    string printImgPath;
    int currTime = 30;


    void Start()
    {
        PrintViewPictureInit();
    }

    void PrintViewPictureInit()
    {
        printImgPath = Application.persistentDataPath + "/Print/PrintPicture.png";
        byte[] printImgData = File.ReadAllBytes(printImgPath);
        Texture2D printTexture = null;
        printTexture = new Texture2D(0, 0);
        printTexture.LoadImage(printImgData);
        viewRawImg.texture = printTexture;
    }

    public void PrintButtonOn()
    {
        GameManager.instance.SFXSound("ClickSound");

        string printerName = "Sinfonia CHC-S2245";  //"Canon SELPHY CP1500";// "Sinfonia CHC-S2245";
        string _rePrintPath = Regex.Replace(printImgPath, "/", "\\");
        string printFullCommand =
            "rundll32 C:\\WINDOWS\\system32\\shimgvw.dll,ImageView_PrintTo " + "\"" + _rePrintPath + "\"" + " " + "\"" + 
            printerName + "\"";

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
                (new Vector3(0f, 0f, -360f), 2.5f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear)
                     .SetLoops(-1);

            StartCoroutine(PrintingWait());
        }
        catch (Exception e)
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
