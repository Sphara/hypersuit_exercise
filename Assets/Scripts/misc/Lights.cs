using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {

    Light lightSource;

	void Start () {
		lightSource = GetComponent<Light>();
    }

    public void ChangeColor(Color color)
    {
        lightSource.color = color;
    }

}
