using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public Material PressedMaterial;
    public Material NotPressedMaterial;

    Renderer renderer;
    Light light;
    AudioSource audiosource;

    protected bool isActive = false;

    public virtual void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        light = GetComponent<Light>();
        audiosource = GetComponent<AudioSource>();
    }

    virtual public void Interact(GameObject InteractionAuthor) {
        isActive = !isActive;

        audiosource.Play();
        if (isActive)
        {
            renderer.material = PressedMaterial;
        }
        else
        {
            renderer.material = NotPressedMaterial;
        }
    }
}
