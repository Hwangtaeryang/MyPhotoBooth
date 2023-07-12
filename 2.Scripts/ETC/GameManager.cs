using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip bgmClip;


    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        BGMSound();

        FrameHorizontalCreation();
        FrameVerticalCreation();
        FrameFourCutCreation();
    }

    public void BGMSound()
    {
        //bgmSource.PlayOneShot(Resources.Load<AudioClip>("Sound/" + _name));
        bgmSource.clip = bgmClip;
        bgmSource.Play();
    }

    public void SFXSound(string _name)
    {
        sfxSource.PlayOneShot(Resources.Load<AudioClip>("Sound/" + _name));
    }


    string framePath_H, framePath_V, framePath_F;
    FileInfo[] frameData_H, frameData_V, frameData_F;
    public int frameMaxIndex_H = 0, frameMaxIndex_V = 0, frameMaxIndex_F = 0;

    public Sprite[] spriteList_H, spriteList_V, spriteList_F;


    public void FrameHorizontalCreation()
    {
        framePath_H = Application.persistentDataPath + "/Frame/Horizontal";

        DirectoryInfo di = new DirectoryInfo(framePath_H);
        frameData_H = di.GetFiles("*.png");
        frameMaxIndex_H = frameData_H.Length;

        spriteList_H = new Sprite[frameMaxIndex_H];


        //필터 갯수에 맞게 생성하기
        for(int i = 0; i < frameMaxIndex_H; i++)
        {
            byte[] frameByte = File.ReadAllBytes(Application.persistentDataPath +
                "/Frame/Horizontal/" + frameData_H[i].Name);
            Texture2D frameTexture = null;
            frameTexture = new Texture2D(0, 0);
            frameTexture.LoadImage(frameByte);

            spriteList_H[i] = Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, 
                frameTexture.height), new Vector2(0, 0));
        }
    }

    public void FrameVerticalCreation()
    {
        framePath_V = Application.persistentDataPath + "/Frame/Vertical";

        DirectoryInfo di = new DirectoryInfo(framePath_V);
        frameData_V = di.GetFiles("*.png");
        frameMaxIndex_V = frameData_V.Length;

        spriteList_V = new Sprite[frameMaxIndex_V];

        for(int i = 0; i < frameMaxIndex_V; i++)
        {
            byte[] frameByte = File.ReadAllBytes(Application.persistentDataPath +
                "/Frame/Vertical/" + frameData_V[i].Name);
            Texture2D frameTexture = null;
            frameTexture = new Texture2D(0, 0);
            frameTexture.LoadImage(frameByte);

            spriteList_V[i] = Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width,
                frameTexture.height), new Vector2(0, 0));
        }
    }


    public void FrameFourCutCreation()
    {
        framePath_F = Application.persistentDataPath + "/Frame/FourCut";

        DirectoryInfo di = new DirectoryInfo(framePath_F);
        frameData_F = di.GetFiles("*.png");
        frameMaxIndex_F = frameData_F.Length;

        spriteList_F = new Sprite[frameMaxIndex_F];

        for(int i = 0; i < frameMaxIndex_F; i++)
        {
            byte[] frameByte = File.ReadAllBytes(Application.persistentDataPath +
                "/Frame/FourCut/" + frameData_F[i].Name);
            Texture2D frameTexture = null;
            frameTexture = new Texture2D(0, 0);
            frameTexture.LoadImage(frameByte);

            spriteList_F[i] = Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width,
                frameTexture.height), new Vector2(0, 0));
        }
    }
}
