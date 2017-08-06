using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public Transform leftDoor;
    public Transform rightDoor;

    public float openingDistance = 2.3f;
    public float openingSpeed = 2.0f;

    public Vector3 raycastAnchor;

    public PowerController pc;

    float leftZ;
    float rightZ;

    float lastMotionDetection = 10.0f;

    int layerMask;
    bool isSoundOnCooldown = false;

    AudioSource audioSource;

    void Start () {
        leftZ = leftDoor.position.z;
        rightZ = rightDoor.position.z;

        layerMask = LayerMask.GetMask("player");
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {

        lastMotionDetection += Time.fixedDeltaTime;

        if (!pc.GetState())
        {
            return;
        }

        Vector3 raycastStart = raycastAnchor;
        raycastStart.x -= 1;

        Debug.DrawRay(raycastStart, transform.forward * 7, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(raycastStart, transform.forward, out hit, 7, layerMask))
        {
            PlaySound();
            lastMotionDetection = 0.0f;
        }

        raycastStart.x += 2;

        Debug.DrawRay(raycastStart, transform.forward * 7, Color.red);

        RaycastHit otherHit;
        if (Physics.Raycast(raycastStart, transform.forward, out otherHit, 7, layerMask))
        {
            PlaySound();
            lastMotionDetection = 0.0f;
        }

        if (lastMotionDetection < 5.0f)
        {
            if (leftDoor.position.z < leftZ + openingDistance)
            {
                leftDoor.Translate(new Vector3(openingSpeed * Time.fixedDeltaTime, 0, 0));
            }

            if (rightDoor.position.z > rightZ - openingDistance)
            {
                rightDoor.Translate(new Vector3(openingSpeed * Time.fixedDeltaTime, 0, 0));
            }
        }
        else
        {
            isSoundOnCooldown = false;

            if (leftDoor.position.z > leftZ)
            {
                leftDoor.Translate(new Vector3(-openingSpeed * Time.fixedDeltaTime, 0, 0));
            }


            if (rightDoor.position.z < rightZ)
            {
                rightDoor.Translate(new Vector3(-openingSpeed * Time.fixedDeltaTime, 0, 0));
            }
        }
    }

    void PlaySound()
    {
        if (isSoundOnCooldown)
            return;

        audioSource.Play();
        isSoundOnCooldown = true;
    }
}
