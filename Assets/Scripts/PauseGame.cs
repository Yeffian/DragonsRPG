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

    public void Pause()
    {
        Time.timeScale = 0.0f;
        _paused = true;
    }

    public void Unpause()
    {
        Time.timeScale = _timeScale;
        _paused = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused == false)
                Pause();
            else if (_paused)
                Unpause();
        }
        
        pauseScreen.SetActive(_paused);
    }
}
