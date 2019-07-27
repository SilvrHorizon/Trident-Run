using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScreen : MonoBehaviour
{

    public void Respawn()
    {
        SceneLoader.Load(SceneLoader.Scenes.SampleScene);
    }
}
