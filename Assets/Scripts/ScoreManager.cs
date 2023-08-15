using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField] private TextMeshProUGUI text;

    private int _maxCoins;
    private SceneTransitionManager _transitionManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _maxCoins = FindObjectsOfType<Coin>().Length;
        _transitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Score: {Score}";
    }

    public void IncrementScore()
    {
        Score += 1;
    }
}
