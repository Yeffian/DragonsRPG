using System;
using UnityEngine;

[Serializable]
public class EnemyController : MovingObject
{
    [SerializeField] private Animator animator;
    [SerializeField] public GameObject FirstPoint;
    [SerializeField] public GameObject Origin;
    [SerializeField] public float Speed;

    // Update is called once per frame
    void Update()
    {
        // Thank you nt314p for this clever solution
        float t = Mathf.PingPong(Time.time * Speed, 1);
        // Debug.Log(t);
        animator.SetFloat("Vertical", t);
        transform.position = Vector3.Lerp(FirstPoint.transform.position, Origin.transform.position, t);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var player = col.gameObject.GetComponent<MovementController>();
            player.Die();
        }
    }
}