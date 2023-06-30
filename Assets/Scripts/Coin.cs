using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreManager score;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           // Debug.Log("coin achieved!");
            Destroy(gameObject);
            score.IncrementScore();   
        }
    }
}
