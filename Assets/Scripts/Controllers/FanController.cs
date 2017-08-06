using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : Interactable {

    public List<Fan> fans;

    public override void Interact(GameObject InteractionAuthor)
    {
        base.Interact(InteractionAuthor);

        foreach (Fan fan in fans)
        {
            fan.Toggle();
        }
    }
}
