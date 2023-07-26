using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUIFunctions : MonoBehaviour
{
    [SerializeField] private PauseGame pauseControls;
    
    public void ReturnButton()
    {
        pauseControls.Unpause();
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#endif

        Application.Quit();
    }
}
