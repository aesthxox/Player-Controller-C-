using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorDetection : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 jump;
    public float jumpForce = 5.0f;
    public float Speed;

    public void grounded()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

    }
}
