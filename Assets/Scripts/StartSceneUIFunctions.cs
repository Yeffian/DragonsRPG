using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUIFunctions : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;
    
    public void StartButton()
    {
        StartCoroutine(LoadLevel(0));
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

    IEnumerator LoadLevel(int idx)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(idx, LoadSceneMode.Single);
    }
}
