using UnityEngine;

public class GameOverUIFunctions : MonoBehaviour
{
    public void GoBackButton()
    {
        var transitionManager = FindObjectOfType<SceneTransitionManager>();
        transitionManager.GoToScene(2);
    }
}
