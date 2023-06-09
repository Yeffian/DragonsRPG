using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreCounter score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("coin achieved!");
        Destroy(gameObject);
        score.IncrementScore();
    }
}
