using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; set; }

    [SerializeField] private TextMeshProUGUI text;

    private int _maxCoins;
    private string _currentSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        _maxCoins = FindObjectsOfType<Coin>().Length;
        _currentSceneName = SceneManager.GetActiveScene().name;
        //Debug.Log("coins in this scene: " + _maxCoins);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Score: {Score}";
        
        if (Score == _maxCoins)
        {
            int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneindex + 1;
            //Debug.Log(currentSceneindex);
            //Debug.Log(currentSceneindex + 1);
            
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings - 2)
            {
                SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
            }
            else
            {
              //  Debug.Log("max scenes reached");
                SceneManager.LoadScene(3);
            }
        }
    }

    public void IncrementScore()
    {
        Score += 1;
    }
}
