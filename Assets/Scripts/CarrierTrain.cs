using System;
using UnityEngine;

public class CarrierTrain : MovingObject
{
    [SerializeField] public GameObject Left;
    [SerializeField] public GameObject Right;
    [SerializeField] public Transform SnapPoint;
    [SerializeField] public float Speed = 0.8f;

    private float t;

    private GameObject player;

    private void Start()
    {
        Debug.Log($"Carrier Name: {gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        var lastPos = transform.position;
        t = Move(Left, Right, Speed);

        if (player != null)
        {
            if (Input.anyKey)
                DropOff();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Pickup(col.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(player != null ? $"{player.name} is picked up" : "no player picked up");
    }

    public void Pickup(GameObject player)
    {
        Debug.Log($"picked up {player.name}");
        this.player = player;
        this.player.transform.SetParent(transform);
        this.player.transform.position = SnapPoint.position;
    }

    public void DropOff()
    {
        if (player == null) return;
        
        // player.transform.position = Right.transform.position;
        player.transform.SetParent(null);
        // player.GetComponent<MovementController>().UnlockMovement();
        player = null;
        // else
        // {
        //     Debug.Log($"{player.name}");
        // }
    }
}
