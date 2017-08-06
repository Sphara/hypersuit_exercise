using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                // Normalement,je ferais un truc plus solide avec des raycast qui ne touchent que certains layers, mais ce n'est pas vraiment la peine pour une démo comme ça
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

                if (interactable)
                {
                    interactable.Interact(gameObject);
                }
            }
        }
	}
}
