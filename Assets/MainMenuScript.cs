using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneLoader.Load(SceneLoader.Scenes.Test2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
