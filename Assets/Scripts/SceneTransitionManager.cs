using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public enum MenuType
    {
        Start, GameOver
    }
    
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1;
    [SerializeField] private GameObject fade;

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

    public (string, string) NextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        int levelIndex = Int32.Parse(Regex.Match(currentSceneName, @"\d+").Value);
        string nextSceneName = $"Level {levelIndex + 1}";
        Debug.Log($"Level {levelIndex + 1} next");

        GoToScene(nextSceneName);
        return (currentSceneName, nextSceneName);
    }

    public void OpenMenu(MenuType menuType)
    {
        switch (menuType)
        {
            case MenuType.Start:
                GoToScene(4);
                break;
            case MenuType.GameOver:
                GoToScene(5);
                break;
        }
    }
}
