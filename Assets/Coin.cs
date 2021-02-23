using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;// Assigned Value of the Coins
    private float rotationSpeed = 50f;//Rotation Speed of the Coins
    private void Update()
    {
        transform.Rotate(0,0,rotationSpeed*Time.deltaTime);
    }
}
