using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;



public class LoadScene : MonoBehaviour
{
    public static LoadScene instance { get; private set; }


    public GameObject loaderBack;
    public Image timerRot;

    private AsyncOperation async;

    [SerializeField]
    Slider sliderBar;


    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else instance = this;
    }

    public void LoadByName(string _loadSceneName)
    {
        timerRot.transform.DORotate(new Vector3(0f, 0f, -360f), 1f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear)
                     .SetLoops(-1);
        loaderBack.SetActive(true);
        StartCoroutine(_LoadScene(_loadSceneName));
    }

    IEnumerator _LoadScene(string _nextScene)
    {
        yield return null;
        async = SceneManager.LoadSceneAsync(_nextScene);

        //allowSceneActivation이 true가 되는 순간이 바로 다음 씬으로 넘어가는 시점
        async.allowSceneActivation = false;

        float timer = 0f;

        while(!async.isDone)
        {
            yield return null;
            timer += Time.deltaTime * 0.01f;

            if (async.progress < 0.9f)
            {
                sliderBar.value = Mathf.Lerp(sliderBar.value, async.progress, timer);
                if (sliderBar.value >= async.progress)
                    timer = 0;
            }
            else
            {
                sliderBar.value = Mathf.Lerp(sliderBar.value, 1f, timer);
                if(sliderBar.value >= 0.99f)
                {
                    async.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    //public void ReloadScene()
    //{
    //    loaderBack.SetActive(true);
    //    async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    //}
}
