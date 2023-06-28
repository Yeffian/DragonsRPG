using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUIFunctions : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        if(EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#endif

        Application.Quit();
    }
}
