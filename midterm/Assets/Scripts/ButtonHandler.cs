using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void NavigateToGameScene()
    {
        Debug.Log("Navigating to the game scene...");
        Loader.Load(Loader.Scene.GameScene);
    }

    public void NavigateToMainScene()
    {
        Debug.Log("Navigating to the MainMenu scene...");
        Loader.Load(Loader.Scene.MainMenu);
    }
}
