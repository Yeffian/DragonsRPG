using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    
    private Vector2 _moveDir;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SceneTransitionManager _transitionManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        // else
        //     Debug.Log("cannot move");
        //
        // Move();
    }

    private void ProcessInputs()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
        
        _animator.SetFloat("Horizontal", _moveDir.x);
        _animator.SetFloat("Vertical", _moveDir.y);
        _animator.SetFloat("Speed", _moveDir.sqrMagnitude);
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_moveDir.x * speedMultiplier, _moveDir.y * speedMultiplier);
    }

    public void Die()
    {
        Destroy(gameObject);
        AudioManager.Instance.PlaySound("Die");
        _transitionManager.GoToScene(SceneManager.GetActiveScene().buildIndex);
    }
}
