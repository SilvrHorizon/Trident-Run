using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedToDoor : MonoBehaviour
{
    public bool isActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Interactable>().onTrigger = () =>
        {
            if (gameObject.GetComponent<ConnectedToDoor>().isActive)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                gameObject.GetComponent<ConnectedToDoor>().isActive = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                gameObject.GetComponent<ConnectedToDoor>().isActive = true;
            }
            gameObject.GetComponentInParent<DoorHandeler>().CheckLockState();
        };
    }

}
