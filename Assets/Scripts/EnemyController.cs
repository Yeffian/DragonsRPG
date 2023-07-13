using System;
using UnityEngine;

[Serializable]
public class EnemyController : MonoBehaviour
{
    private enum TraversalDirection
    {
        OriginToFirst,
        FirstToOrigin
    }

    [SerializeField] public GameObject FirstPoint;
    [SerializeField] public GameObject Origin;
    [SerializeField] public float Speed;

    private TraversalDirection _dir;
    private GameObject _target;

    private TraversalDirection ReverseDirection(TraversalDirection dir)
        => dir == TraversalDirection.OriginToFirst ? TraversalDirection.FirstToOrigin : TraversalDirection.OriginToFirst;

         // Start is called before the first frame update
    void Start()
    {
        _target = FirstPoint;
        _dir = TraversalDirection.OriginToFirst;
    }

    // Update is called once per frame
    void Update()
    {
        // Thank you nt314p for this clever solution
        transform.position = Vector3.Lerp(FirstPoint.transform.position, Origin.transform.position, Mathf.PingPong(Time.time * Speed, 1));
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