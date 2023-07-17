using UnityEngine;

public class CarrierTrain : MovingObject
{
    [SerializeField] public GameObject Left;
    [SerializeField] public GameObject Right;
    [SerializeField] public float Speed = 0.8f;

    private float t;

    private GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        t = Move(Left, Right, Speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Pickup(col.gameObject);
        }
    }
    
    public void Pickup(GameObject player)
    {
        this.player = player;
        player.transform.SetParent(transform);
    }

    public void DropOff()
    {
        if (player != null)
        {
            player.transform.SetParent(null);
            player = null;
        }
    }
}
