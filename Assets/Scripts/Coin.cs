using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneTransitionManager;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreManager score;
    [SerializeField] private float scaleFactor;
    [SerializeField] private float scaleTime;
    
    private int _maxCoins;
    private SceneTransitionManager _transitionManager;

    void Start()
    {
        _maxCoins = FindObjectsOfType<Coin>().Length;
        _transitionManager = FindObjectOfType<SceneTransitionManager>();
        //Debug.Log("coins in this scene: " + _maxCoins);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           AddCoin();
           
           if (score.Score == _maxCoins)
           {
               int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
               int nextSceneIndex = currentSceneindex + 1;
               Debug.Log($"The index of the next scene is {nextSceneIndex}");
               // //Debug.Log(currentSceneindex);
               // //Debug.Log(currentSceneindex + 1);
               //
               if (nextSceneIndex < SceneManager.sceneCountInBuildSettings - 2)
               {
               //     // SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
                   AudioManager.Instance.PlaySound("Next Level");
                   (string current, string next) = _transitionManager.NextLevel();
                   Debug.Log(current == next);
                   // Debug.Log($"{nextSceneIndex} < {SceneManager.sceneCountInBuildSettings - 2} = );
               }
               else
               {
                   Debug.Log("max scenes reached");
                   var transitionManager = FindObjectOfType<SceneTransitionManager>();
                   transitionManager.OpenMenu(MenuType.GameOver);          
               }
           }
        }
    }

    private void AddCoin()
    {
        var originalScale = gameObject.transform.localScale;
        var finalScale = new Vector3(originalScale.x + scaleFactor, originalScale.y + scaleFactor, originalScale.z + scaleFactor);
        AudioManager.Instance.PlaySound("Pickup Coin");
        gameObject.transform.DOScale(finalScale, scaleTime).onComplete = () => Destroy(gameObject);
        score.IncrementScore();  
    }
}
