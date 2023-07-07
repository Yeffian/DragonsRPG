using UnityEngine;
using static SceneTransitionManager;

public class GameOverUIFunctions : MonoBehaviour
{
    public void GoBackButton()
    {
        var transitionManager = FindObjectOfType<SceneTransitionManager>();
        transitionManager.OpenMenu(MenuType.Start);
    }
}
