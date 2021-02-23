using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float speed = 5f;
    // Use this for initialization
    void Start () 
    {
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
	    Vector3 newPosition = player.transform.position - player.transform.forward * offset.z - player.transform.up * offset.y;
	    transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * speed);

        var newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
        
       }
}
