using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    
    private bool _paused;
    private float _timeScale;

    private void Start()
    {
        _timeScale = Time.timeScale;
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused == false)
            {
                Time.timeScale = 0.0f;
                _paused = !_paused;
            }
            else if (_paused)
            {
                Time.timeScale = _timeScale;
                _paused = !_paused;
            }
        }
        
        pauseScreen.SetActive(_paused);
    }
}
