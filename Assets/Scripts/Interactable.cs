using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Action onTrigger;

    public void Interact()
    {
        onTrigger();
    }
}
