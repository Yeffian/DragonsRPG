using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    public float Move(GameObject firstPoint, GameObject origin, float speed)
    {
        // Thank you nt314p for this clever solution
        float t = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(firstPoint.transform.position, origin.transform.position, t);

        return t;
    }
}
