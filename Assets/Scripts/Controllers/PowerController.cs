using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : Interactable {

    public Material material;

    [Range(0.0f, 1.0f)]
    public float lightLevel = 0.2f;

	void FixedUpdate () {

        if (isActive)
        {
            if (lightLevel < 1)
            {
                lightLevel += 0.2f * Time.fixedDeltaTime;
            }
        }
        else
        {
            if (lightLevel > 0.2f)
            {
                lightLevel -= 0.2f * Time.fixedDeltaTime;
            }
        }

       lightLevel = Mathf.Clamp01(lightLevel);
       material.color = Color.Lerp(Color.black, Color.white, lightLevel);
    }

    public bool GetState()
    {
        return isActive;
    }

    public override void Interact(GameObject InteractionAuthor)
    {
        base.Interact(InteractionAuthor);
    }
}
