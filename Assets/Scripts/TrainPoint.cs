using UnityEngine;

public class TrainPoint : MonoBehaviour
{
    [SerializeField] private bool dropOff;

    public bool lastDropped;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Carrier"))
        {
            CarrierTrain train = col.gameObject.GetComponent<CarrierTrain>();

            // if (dropOff)
            // {
            //     // Debug.Log("should drop off here");
            //     // if (lastDropped == false)
            //     // {
            //     //     train.DropOff();
            //     //     lastDropped = !lastDropped;
            //     // }
            //     
            //     train.DropOff();
            // }
        }
    }
}
