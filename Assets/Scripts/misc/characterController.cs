using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

	public float speed = 10.0f;
    bool isJumping = false;

    float yVelocity = 0;
    float timeSinceLastJump = 0;

	void Start () 
	{
        Cursor.lockState = CursorLockMode.Locked;
	}

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint cp in collision.contacts)
        {
            Vector3 relativeContactPoint = transform.InverseTransformPoint(cp.point);

            if (relativeContactPoint.y > 0.5f)
            {
                yVelocity = 0;
            }

        }
    }

    void FixedUpdate () {
	
        float translation = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        float strafe = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        timeSinceLastJump += Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastJump > .5f)
        {
            isJumping = false;
            yVelocity = 0.5f;
            timeSinceLastJump = 0;
        }
        else
        {
            yVelocity -= 1.0f * Time.fixedDeltaTime;
            if (yVelocity < 0)
                yVelocity = 0;
        }

        transform.Translate(strafe, yVelocity, translation);

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

	}

}
