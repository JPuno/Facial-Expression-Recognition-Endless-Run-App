using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // loading scene by using the name of the scene
    public void SceneManagerr(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
