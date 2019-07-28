using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScene : MonoBehaviour
{
    [SerializeField] GameObject exitDoor;
    private void Awake()
    {
        exitDoor.GetComponent<DoorHandeler>().onEnter = () =>
        {
            SceneLoader.LoadNextScene();
            SceneLoader.SetLastScene();
        };
    }
}
