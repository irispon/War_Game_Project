using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceanLoader : MonoBehaviour
{

    public string sceanName;
    public void Click()
    {
        LoadingSceneManager.LoadScene(sceanName);
    }
    public void Click(string name)
    {
        LoadingSceneManager.LoadScene(name);
    }

}
