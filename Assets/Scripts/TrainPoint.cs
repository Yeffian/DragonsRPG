using UnityEngine;

public class TrainPoint : MonoBehaviour
{
    [SerializeField] private bool dropOff;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Carrier")
        {
            Debug.Log("drop off here");
            CarrierTrain train = col.gameObject.GetComponent<CarrierTrain>();

            if (dropOff)
                train.DropOff();
        }
    }
}
