using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score { get; set; }

    [SerializeField] private TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
