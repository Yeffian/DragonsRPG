using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIFunctions : MonoBehaviour
{
    public void GoBackButton()
    {
        var transitionManager = FindObjectOfType<SceneTransitionManager>();
        transitionManager.GoToScene(2);
    }
}
