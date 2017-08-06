using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

    bool isWorking = false;
    float rotationSpeed = 0.0f;
    AudioSource fanNoiseSource;

    public float maxRotationSpeed = 50.0f;
    public float accelerationSpeed = 0.1f; // Is also the deceleration speed

    private void Start()
    {
        fanNoiseSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {

        if (isWorking == true)
        {
            if (rotationSpeed < maxRotationSpeed)
                rotationSpeed += accelerationSpeed * Time.fixedDeltaTime;
        }
        else
        {
            if (rotationSpeed > 0.0f)
                rotationSpeed -= accelerationSpeed * Time.fixedDeltaTime;
        }

        Mathf.Clamp(accelerationSpeed, 0.0f, maxRotationSpeed);
        fanNoiseSource.volume = Mathf.InverseLerp(0.0f, maxRotationSpeed, rotationSpeed);

        if (rotationSpeed > 0.0f)
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.fixedDeltaTime));
    }


    public void Toggle()
    {
        isWorking = !isWorking;
    }
}
