using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy_Multi : MonoBehaviour
{
    public float ss;
    private Rigidbody rb;
    public Player_multi player_multiScript;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * -ss, ForceMode.Impulse);
        player_multiScript = FindObjectOfType<Player_multi>();
    }

    //Damage function
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("Progectile Collision Detected");
            player_multiScript.m_Score++;
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
