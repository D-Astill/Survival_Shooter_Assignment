using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class EnemyScript : MonoBehaviour
{
    public float ss;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * -ss, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
