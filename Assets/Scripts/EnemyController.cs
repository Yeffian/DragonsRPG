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
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Traversal Point"))
        {
            _dir = ReverseDirection(_dir);

           // Debug.Log(_dir);
           // Debug.Log(_target.name);
            _target = _dir == TraversalDirection.FirstToOrigin ? FirstPoint : Origin;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // TODO: Scene transitions
            AudioManager.Instance.PlaySound("Die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}