using System;
using System.Collections;
using System.Text.RegularExpressions;
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
    
    private IEnumerator LoadScene(string name)
    {
        fade.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void GoToScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }
    
    public void GoToScene(string name)
    {
        StartCoroutine(LoadScene(name));
    }

    public void NextLevel()
    {
        int levelIndex = Int32.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value);
        string nextSceneName = $"Level {levelIndex + 1}";
        
        // TODO: Figure out the exploding sound 
        AudioManager.Instance.PlaySound("Next Level");
        GoToScene(nextSceneName);
    }
}
