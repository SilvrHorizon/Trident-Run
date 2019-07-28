using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scenes
    {
        SampleScene,
        TestScene,
        RespawnScreen,
        Test2,
        MainMenu
    }

    public static int LastSceneIndex = SceneManager.GetActiveScene().buildIndex;

    public static void SetLastScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        LastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(LastSceneIndex);
    }

    public static void Load(Scenes toLoad)
    {
        SceneManager.LoadScene(toLoad.ToString());
    }

    public static void LoadLastScene()
    {
        SceneManager.LoadScene(LastSceneIndex);
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}