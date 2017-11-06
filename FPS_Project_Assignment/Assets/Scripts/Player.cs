using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    private Rigidbody rb;
    public float ms;
    public float ds_speed;
    public bool isMoving;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            rb.AddForce(Vector3.up * ms * Time.deltaTime);
            isMoving = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;

            rb.AddForce(Vector3.up * -ms * Time.deltaTime);
            isMoving = false;
        }
        if (!isMoving)
        {
            rb.velocity = Vector3.zero;
        }

    }
}
