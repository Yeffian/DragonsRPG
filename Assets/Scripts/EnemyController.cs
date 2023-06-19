using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private TraversalDirection dir;
    private GameObject target;

    private TraversalDirection ReverseDirection(TraversalDirection dir)
        => dir == TraversalDirection.OriginToFirst ? TraversalDirection.FirstToOrigin : TraversalDirection.OriginToFirst;

         // Start is called before the first frame update
    void Start()
    {
        target = FirstPoint;
        dir = TraversalDirection.OriginToFirst;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Traversal Point"))
        {
            dir = ReverseDirection(dir);

            Debug.Log(dir);
            Debug.Log(target.name);
            target = dir == TraversalDirection.FirstToOrigin ? FirstPoint : Origin;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // TODO: Scene transitions
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}