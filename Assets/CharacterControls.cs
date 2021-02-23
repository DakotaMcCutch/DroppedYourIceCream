using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
	public float rotationSpeed = 30f;
	public float movementSpeed = 2f;

	private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
	    originalPosition = transform.position;
    }

    
    void Update()
    {
	    if (Input.GetKey(KeyCode.W))
	    {
		   Vector3 moveDirection = transform.TransformDirection(Vector3.forward)* (Time.deltaTime * movementSpeed);

		   transform.position += (moveDirection);
	    }
	    else if (Input.GetKey(KeyCode.S))
	    {
		    Vector3 moveDirection = transform.TransformDirection(Vector3.back)* (Time.deltaTime * movementSpeed);
		    transform.position += (moveDirection);
	    }
	    
	    if (Input.GetKey(KeyCode.A))
	    {
		    transform.Rotate(0,-rotationSpeed*Time.deltaTime,0);

	    }
	    else if (Input.GetKey(KeyCode.D))
	    {
		    transform.Rotate(0,rotationSpeed*Time.deltaTime,0);

	    }
    }

    private void OnTriggerEnter(Collider other)
    {
	    if (other.gameObject.GetComponent<Coin>() != null)
	    {
		    GameMaster.Instance.CoinCollected(other.gameObject.GetComponent<Coin>().value);
		    Destroy(other.gameObject);
	    }
	    else if (other.gameObject.GetComponent<ResetFloor>() != null)
	    {
		    ResetFloorHit();
	    }
    }

    private void ResetFloorHit()
    {
	    transform.position = originalPosition;
    }
}
