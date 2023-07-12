using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDPhotoTakePicture : MonoBehaviour
{
    public GameObject canvas_3x4;
    public GameObject canvas_35x45;
    public GameObject camera_3x4;
    public GameObject camera_35x45;

    public RawImage main_3x4RawImg;
    public RawImage main_35x45RawImg;
    public RawImage ui_3x4RawImg;
    public RawImage ui_35x45RawImg;

    WebCamDevice[] webCamDevices;
    WebCamTexture webCamTexture;



    void Start()
    {
        if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
        {
            canvas_3x4.SetActive(true);
            canvas_35x45.SetActive(false);
            camera_3x4.SetActive(true);
            camera_35x45.SetActive(false);
            ui_3x4RawImg.gameObject.SetActive(true);
            ui_35x45RawImg.gameObject.SetActive(false);
        }
        else if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
        {
            canvas_35x45.SetActive(true);
            canvas_3x4.SetActive(false);
            camera_35x45.SetActive(true);
            camera_3x4.SetActive(false);
            ui_35x45RawImg.gameObject.SetActive(true);
            ui_3x4RawImg.gameObject.SetActive(false);
        }

        //���� ��� ������ ī�޶� ����Ʈ
        webCamDevices = WebCamTexture.devices;

        //����� ī�޶� ����
        //���� ó�� �˻��Ǵ� �ĸ� ī�޶� ���
        //int cameraIndex = -1;
        for (int i = 0; i < webCamDevices.Length; i++)
        {
            //�� �ĸ� ī�޶����� üũ
            //if (webCamDevices[i].isFrontFacing.Equals(false))
            //{
            //    //�ش�ī�޶� ����
            //    cameraIndex = i;
            //    break;
            //}

            //�ĸ� ī�޶� �ƴ��� üũ
            if (webCamDevices[i].isFrontFacing.Equals(true))
            {
                //���õ� ī�޶� ���� ���ο� WebCamTexture����
                webCamTexture = new WebCamTexture(webCamDevices[i].name);
                break;
            }
        }

        //ī�޶� �����϶� �¿� ������Ű��
        if (!webCamTexture.videoVerticallyMirrored)
        {
            if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
            {
                Vector3 scaletmp = main_3x4RawImg.GetComponent<RectTransform>().localScale;
                scaletmp.x = -1;
                //main_3x4RawImg.GetComponent<RectTransform>().localScale = scaletmp;
                ui_3x4RawImg.GetComponent<RectTransform>().localScale = scaletmp;
            }
            else if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
            {
                Vector3 scaletmp = main_35x45RawImg.GetComponent<RectTransform>().localScale;
                scaletmp.x = -1;
                //main_35x45RawImg.GetComponent<RectTransform>().localScale = scaletmp;
                ui_35x45RawImg.GetComponent<RectTransform>().localScale = scaletmp;
            }
        }



        //���ϴ� FPS����
        if (webCamTexture != null)
        {
            webCamTexture.requestedFPS = 60f;

            if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
            {
                //main_3x4RawImg.texture = webCamTexture;
                ui_3x4RawImg.texture = webCamTexture;
            }
            else if(PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
            {
                //main_35x45RawImg.texture = webCamTexture;
                ui_35x45RawImg.texture = webCamTexture;
            }
            webCamTexture.Play();
        }
    }


    private void OnDestroy()
    {
        //WebCamTexture���ҽ� ��ȯ
        if(webCamTexture != null)
        {
            webCamTexture.Stop();
            WebCamTexture.Destroy(webCamTexture);
        }
    }
}
