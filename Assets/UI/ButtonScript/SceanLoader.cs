using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceanLoader : MonoBehaviour
{

    public void Click()
    {
        LoadingSceneManager.LoadScene(gameObject.name);
    }
    public void Click(string name)
    {
        LoadingSceneManager.LoadScene(name);
    }

}
