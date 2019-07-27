using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scenes
    {
        SampleScene
    }

    public static void Load(Scenes toLoad)
    {
        SceneManager.LoadScene(toLoad.ToString());
    }
}
