using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[RequireComponent(typeof(Rigidbody))]
public class Player : NetworkBehaviour {

    private Rigidbody rb;
    public float ms;
    public float ds_speed;
    public Camera cam;
    //public Vector3 TransformClamp;

	// Use this for initialization
	void Awake () {
        gameObject.SetActive(true);
        if (!isLocalPlayer)
        {
            cam = FindObjectOfType<Camera>();
            rb = GetComponent<Rigidbody>();

        }
        
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        //TransformClamp.x = Mathf.Clamp(transform.position.x, -4.5f, 4.5f);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * ms ,ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.up * -ms, ForceMode.Impulse);
        }
    }
}
