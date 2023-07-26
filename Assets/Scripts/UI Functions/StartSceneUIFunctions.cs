using UnityEditor;
using UnityEngine;

public class StartSceneUIFunctions : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;
    
    public void StartButton()
    {
        var transitionManager = FindObjectOfType<SceneTransitionManager>();
        transitionManager.GoToScene(0);
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
