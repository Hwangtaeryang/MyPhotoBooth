using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScrolling : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;
    float clickValue;


    void Start()
    {
        //배경이 생길때마다 움직이는 길이의 값이 틀려지기 때문에
        clickValue = 1f / transform.childCount;
    }

    
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
            pos[i] = distance * i;

        if(Input.GetMouseButton(0))
        {
            //GameManager.instance.SFXSound("ClickSound");
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < pos.Length; i++)
            {
                if(scroll_pos < pos[i] + (distance / 2 ) && scroll_pos > pos[i] - (distance / 2 ))
                {
                    scrollbar.GetComponent<Scrollbar>().value = 
                        Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for(int i = 0; i < pos.Length; i++)
        {
            if(scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = 
                    Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                ChromakeyBackImageChoiceManager.backImgIndex = i;   //선택한 백배경 인덱스 저장

                for (int j = 0; j < pos.Length; j++)
                {
                    if(j != i)
                    {
                        transform.GetChild(j).localScale =
                            Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.9f, 0.9f), 0.1f);
                    }
                }
            }
        }
    }
}
