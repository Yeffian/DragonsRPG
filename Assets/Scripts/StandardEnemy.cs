using System;
using UnityEngine;

[Serializable]
public class StandardEnemy : MovingObject
{
    [SerializeField] public GameObject FirstPoint;
    [SerializeField] public GameObject Origin;
    [SerializeField] public float Speed;
    [SerializeField] private bool horizontal;

    private bool upDown;
    private Animator _animator;

    private void Start()
    {
        upDown = true;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Thank you nt314p for this clever solution
        // float t = Mathf.PingPong(Time.time * Speed, 1);
        // Debug.Log(t);

        Move(FirstPoint, Origin, Speed);
        _animator.Play(upDown ? "anim_updown" : "anim_downup");
        // transform.position = Vector3.Lerp(FirstPoint.transform.position, Origin.transform.position, t);
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