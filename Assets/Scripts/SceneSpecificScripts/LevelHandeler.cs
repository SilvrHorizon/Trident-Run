using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandeler : MonoBehaviour
{
    [SerializeField] GameObject exitDoor;
    [SerializeField] SceneLoader.Scenes nextLevel;

    private void Awake()
    {
        exitDoor.GetComponent<DoorHandeler>().onEnter = () =>
        {
            SceneLoader.Load(nextLevel);
        };
        Destroy(gameObject);
    }
}
