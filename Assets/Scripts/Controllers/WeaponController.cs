using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public Vector3 rotationSpeed;
    public PowerController powerController;

	void Update () {
        if (powerController.GetState())
            transform.Rotate(new Vector3(rotationSpeed.x * Time.fixedDeltaTime, rotationSpeed.y * Time.fixedDeltaTime, rotationSpeed.z * Time.fixedDeltaTime));
    }
}
