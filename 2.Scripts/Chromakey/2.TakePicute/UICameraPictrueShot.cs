using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UICameraPictrueShot : MonoBehaviour
{
    private static UICameraPictrueShot instance;

    Camera uiCamera;
    bool takeScreenShotOnNextFrame;


    string id_folderPath;
    int pictureCount;


    void Start()
    {
        instance = this;
        uiCamera = gameObject.GetComponent<Camera>();
    }

    private void OnEnable()
    {
        RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
    }

    private void OnDisable()
    {
        RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
    }

    private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext _context, Camera _camera)
    {
        OnPostRender();
    }

    private void OnPostRender()
    {
        if(takeScreenShotOnNextFrame)
        {
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = uiCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();

            FolderPath(byteArray);

            RenderTexture.ReleaseTemporary(renderTexture);
            uiCamera.targetTexture = null;
        }
    }

    void FolderPath(byte[] _byteArray)
    {
        if(SceneManager.GetActiveScene().name.Equals("1_2_TakePicture"))
        {
            string folderPath = Application.persistentDataPath + "/ChromakeyBasicPictureShot";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + "/ChromakeyBasicPictureShot/BasicPicture.png", _byteArray);
            GameManager.instance.SFXSound("CameraShutter");
        }
        else if(SceneManager.GetActiveScene().name.Equals("1_3_PictureCompose") ||
            SceneManager.GetActiveScene().name.Equals("2_3_FrameChoice") ||
            SceneManager.GetActiveScene().name.Equals("3_1_3_VerticalFrameChoice") ||
            SceneManager.GetActiveScene().name.Equals("3_2_4_IDPhotoFramePrint") ||
            SceneManager.GetActiveScene().name.Equals("4_4_FourFrameChoice"))
        {
            string folderPath = Application.persistentDataPath + "/Print";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + "/Print/PrintPicture.png", _byteArray);
        }
        else if(SceneManager.GetActiveScene().name.Equals("2_1_HorizontalTakePicture"))
        {
            string folderPath = Application.persistentDataPath + "/HoriBasicPictureShot";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + "/HoriBasicPictureShot/BasicPictrue.png", _byteArray);
            GameManager.instance.SFXSound("CameraShutter");
        }
        else if(SceneManager.GetActiveScene().name.Equals("2_2_FilterChoice"))
        {
            string folderPath = Application.persistentDataPath + "/HoriFilterComposePicture";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + "/HoriFilterComposePicture/H_FilterPicture.png", _byteArray);
        }
        else if(SceneManager.GetActiveScene().name.Equals("3_1_1_VerticalTakePicture"))
        {
            string folderPath = Application.persistentDataPath + "/VertBasicPictureShot";

            //폴더 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + "/VertBasicPictureShot/BasicPicture.png", _byteArray);
            GameManager.instance.SFXSound("CameraShutter");
        }
        else if(SceneManager.GetActiveScene().name.Equals("3_1_2_VerticalFilterChoice"))
        {
            string folderPath = Application.persistentDataPath + "/VertiFilterComposePicture";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + "/VertiFilterComposePicture/V_FilterPicture.png", _byteArray);
        }
        else if(SceneManager.GetActiveScene().name.Equals("3_2_2_IDPhotoTakePicture"))
        {

            if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
                id_folderPath = Application.persistentDataPath + "/ID_Photo/3x4Photo";
            else if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
                id_folderPath = Application.persistentDataPath + "/ID_Photo/35x45Photo";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(id_folderPath).Equals(false))
                Directory.CreateDirectory(id_folderPath);

            if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3*4"))
                File.WriteAllBytes(Application.persistentDataPath + "/ID_Photo/3x4Photo/3x4Picture.png", _byteArray);
            else if (PlayerPrefs.GetString("MyPhoto_IDPhotoSize").Equals("3.5*4.5"))
                File.WriteAllBytes(Application.persistentDataPath + "/ID_Photo/35x45Photo/35x45Pictrue.png", _byteArray);

            GameManager.instance.SFXSound("CameraShutter");
        }
        else if(SceneManager.GetActiveScene().name.Equals("3_2_3_IDPhotoFilter"))
        {
            string folderPath = Application.persistentDataPath + "/ID_FilterComposePicture";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + "/ID_FilterComposePicture/ID_FilterPicture.png", _byteArray);
        }
        else if (SceneManager.GetActiveScene().name.Equals("4_1_FourCutTakePicture"))
        {
            string folderPath = Application.persistentDataPath + "/FourCutPicture";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + 
                "/FourCutPicture/FourCutPicture" + pictureCount + ".png", _byteArray);
        }
        else if(SceneManager.GetActiveScene().name.Equals("4_3_FourFilterChoice"))
        {
            string folderPath = Application.persistentDataPath + "/FourCut_FilterComposePicture";

            //폴더가 없으면 생성한다.
            if (Directory.Exists(folderPath).Equals(false))
                Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(Application.persistentDataPath + 
                "/FourCut_FilterComposePicture/FourCutFilterPicture.png", _byteArray);
        }
        
    }

    void UiTakePictureShot(int _width, int _height, int _count)
    {
        pictureCount = _count;
        uiCamera.targetTexture = RenderTexture.GetTemporary(_width, _height, 64);
        takeScreenShotOnNextFrame = true;
    }

    public static void Static_UiTeakePictureShot(int _width, int _height, int _count)
    {
        instance.UiTakePictureShot(_width, _height, _count);
    }
}
