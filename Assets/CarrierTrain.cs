using UnityEngine;

public class CarrierTrain : MovingObject
{
    [SerializeField] public GameObject Left;
    [SerializeField] public GameObject Right;
    [SerializeField] public float Speed = 0.8f;

    private float t;
    
    // Update is called once per frame
    void Update()
    {
        t = Move(Left, Right, Speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Pickup();
        }
    }
    
    public void Pickup()
    {
        Debug.Log("pickup");
    }

    public void DropOff()
    {
        Debug.Log("drop off");
    }
    
    //
    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     collision.gameObject.transform.position = t > 0.5f ? left.position : right.position;
    //
    //     Debug.Log(t);
    // }
    //
    // private void OnCollisionExit2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("hit player");
    //         col.transform.SetParent(null);
    //     }
    // }
}
