using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScreen : MonoBehaviour
{

    public void Respawn()
    {
        SceneLoader.LoadLastScene();
    }

    public void Quit()
    {
        SceneLoader.Load(SceneLoader.Scenes.MainMenu);
    }
}
