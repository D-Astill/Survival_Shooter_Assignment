using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy_Single : MonoBehaviour
{
    //Initial Force For Projectiles
    public float m_IniForce;
    //rigidbody on player
    private Rigidbody rb;
    //Single player script
    private Player pS;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * -m_IniForce, ForceMode.Impulse);
        pS = FindObjectOfType<Player>();
    }
    //Damage function
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("Progectile Collision Detected");
            pS.m_Score++;
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
