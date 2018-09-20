using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    private Scene SceneName;
    private string SceneNameS;

    public void reloadScene()
    {
        SceneName = SceneManager.GetActiveScene();
        SceneNameS = SceneName.ToString();
        SceneManager.LoadScene(SceneNameS);

    }
}