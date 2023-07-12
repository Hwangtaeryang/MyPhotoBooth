using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public RawImage rawImg;
    WebCamDevice[] webCamDevices;
    WebCamTexture webCamTexture;



    void Start()
    {
        webCamDevices = WebCamTexture.devices;

        for(int i = 0; i < webCamDevices.Length; i++)
        {
            if(webCamDevices[i].isFrontFacing.Equals(true))
            {
                webCamTexture = new WebCamTexture(webCamDevices[i].name);
                break;
            }
        }

        //카메라가 반전일때 좌우 반전시키기
        if (!webCamTexture.videoVerticallyMirrored)
        {
            Vector3 scaletmp = rawImg.GetComponent<RectTransform>().localScale;
            scaletmp.x= -1;
            rawImg.GetComponent<RectTransform>().localScale = scaletmp;
        }

        if (webCamTexture != null)
        {
            webCamTexture.requestedFPS = 60f;

            rawImg.texture = webCamTexture;
            webCamTexture.Play();
        }
    }

    private void OnDestroy()
    {
        if(webCamTexture != null)
        {
            webCamTexture.Stop();
            WebCamTexture.Destroy(webCamTexture);
        }
    }


}
