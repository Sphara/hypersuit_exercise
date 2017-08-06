using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Interactable {

    public List<Lights> lights;
    List<Color> colorList;

    public override void Start()
    {
        base.Start();

        colorList = new List<Color>
        {
            Color.red,
            Color.blue,
            Color.green,
            Color.yellow,
            Color.magenta,
            Color.white,
            Color.cyan
        };
    }

    public override void Interact(GameObject InteractionAuthor)
    {
        base.Interact(InteractionAuthor);

        Color color = colorList[Random.Range(0, colorList.Count)];

        foreach (Lights light in lights)
        {
            light.ChangeColor(color);
        }
    }
}
