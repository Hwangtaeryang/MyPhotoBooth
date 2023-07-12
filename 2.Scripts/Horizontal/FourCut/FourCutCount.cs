using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class FourCutCount : MonoBehaviour
{
    public TextMeshProUGUI pictureCount;
    public GameObject countDownObj;

    int count = 0;


    void Start()
    {
        pictureCount.text = count.ToString();
    }


    private void FixedUpdate()
    {
        if (countDownObj.activeSelf.Equals(true))
        {
            if (count != CountDown.PictureCount())
            {
                count = CountDown.PictureCount();
                pictureCount.text = count.ToString();
            }
        }
    }
}
