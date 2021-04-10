using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : interactball
{
    public RPGItem item;
    public override void Interact()
    {
        base.Interact();

        Pick();

    }
    void Pick()
    {
        Debug.Log("use item" + item.name);
        Destroy(gameObject);
    }
}
