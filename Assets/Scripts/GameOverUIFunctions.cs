using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIFunctions : MonoBehaviour
{
    public void GoBackButton()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
