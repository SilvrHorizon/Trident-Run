using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruchPillarHead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneLoader.Load(SceneLoader.Scenes.RespawnScreen);
    }
}
