using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandeler : MonoBehaviour
{
    public enum DoorStates
    {
        Locked,
        Closed,
        Open
    }

    [SerializeField] DoorStates doorState;

    ConnectedToDoor[] lockSwitches;
    private void Start()
    {
        lockSwitches = gameObject.GetComponentsInChildren<ConnectedToDoor>();
        foreach(ConnectedToDoor a in lockSwitches)
        {
            Debug.Log(a.gameObject);
        }

        CheckLockState();
    }

    public void CheckLockState()
    {
        bool isLocked = false;
        foreach(ConnectedToDoor lockSwitch in lockSwitches){
            if (!lockSwitch.isActive)
            {
                isLocked = true;
            }
        }

        if (isLocked)
        {
            SetDoorState(DoorStates.Locked);
        } else if(doorState == DoorStates.Locked)
        {
            SetDoorState(DoorStates.Closed);
        }
        Debug.Log(doorState);
    }

    void SetDoorState(DoorStates newState)
    {
        doorState = newState;
        if(doorState == DoorStates.Locked)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        } else if (doorState == DoorStates.Closed)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }else if (doorState == DoorStates.Open)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

}
