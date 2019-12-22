using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour

{
    enum Load
    {
        Scene,Another

    }

    public static string nextScene;
    public static string context;
   

    private Image progressBar;
    private Text progressText;

    private void Awake()
    {

    }

    private void Start()

    {
        progressBar = GameObject.Find("progressbar").GetComponent<Image>();
        progressText = GameObject.Find("progressText").GetComponent<Text>();
        StartCoroutine(LoadScene());

    }


    public static void LoadScene(string sceneName)

    {

        LoadScene(sceneName, "");

    }

    public static void LoadScene(string sceneName, string LoadContext)

    {

        nextScene = sceneName;
        context = LoadContext;
        SceneManager.LoadScene("Progress");

    }
    public static void setText(string LoadContext)

    {
        context = LoadContext;
    }

    IEnumerator LoadScene()

    {

        yield return null;


        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        op.allowSceneActivation = false;


        float timer = 0.0f;

        while (!op.isDone)

        {

            yield return null;


            timer += Time.deltaTime;

            progressText.text = context;
            if (op.progress < 0.9f)

            {

                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);//op.pogress => 진행도, timer= 얼마나 부드럽게 움직이는가? 차는 시간 그런 느낌일 듯
                Debug.Log(timer);
                if (progressBar.fillAmount >= op.progress)

                {
              
                    timer = 0f;

                }

            }

            else

            {

                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);


                if (progressBar.fillAmount == 1.0f)

                {

                    op.allowSceneActivation = true;

                    yield break;

                }

            }

        }

    }

}
