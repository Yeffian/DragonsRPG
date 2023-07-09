using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneTransitionManager;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreManager score;
    
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
           //   Debug.Log("coin achieved!");
           AudioManager.Instance.PlaySound("Pickup Coin");
           Destroy(gameObject);
           score.IncrementScore();   
           
           if (score.Score == _maxCoins)
           {
               int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
               int nextSceneIndex = currentSceneindex + 1;
               //Debug.Log(currentSceneindex);
               //Debug.Log(currentSceneindex + 1);
            
               if (nextSceneIndex < SceneManager.sceneCountInBuildSettings - 2)
               {
                   // SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
                   AudioManager.Instance.PlaySound("Next Level");
                   _transitionManager.NextLevel();
               }
               else
               {
                   //  Debug.Log("max scenes reached");
                   var transitionManager = FindObjectOfType<SceneTransitionManager>();
                   transitionManager.OpenMenu(MenuType.GameOver);               
               }
           }
        }
    }
}
