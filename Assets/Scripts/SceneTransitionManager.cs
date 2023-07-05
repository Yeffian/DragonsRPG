using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1;
    [SerializeField] private GameObject fade;

    private Canvas _canvas;
    
    // Start is called before the first frame update
    void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
    }

    private IEnumerator LoadScene(int idx)
    {
        fade.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(idx, LoadSceneMode.Single);
    }

    public void GoToScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }
}
