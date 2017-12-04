using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class Player_multi : NetworkBehaviour
{

    private Rigidbody rb;
    public float ms;
    public Camera cam;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public const int m_maxHealth = 5;
    public Slider health_display;
    public int m_Score;
    [SyncVar] public int m_currentHealth = m_maxHealth;
    public bool DestroyOnDeath;
    private NetworkStartPosition[] spawnPoints;

    void Awake()
    {
        //Sets the game object active
        gameObject.SetActive(true);
        if (!isLocalPlayer)
        {
            cam = FindObjectOfType<Camera>();
            rb = GetComponent<Rigidbody>();
            health_display = FindObjectOfType<Slider>();
            health_display.maxValue = m_maxHealth;
            health_display.value = m_currentHealth;
        }

    }
    void Start()
    {
        //Finds the Start location set on the network
        spawnPoints = FindObjectsOfType<NetworkStartPosition>();
    }
    //Damage Function 
    public void TakeDamage(int Amount)
    {
        if (!isServer)
        {
            return;
        }
        m_currentHealth -= Amount;
        if (m_currentHealth <= 0)
        {
            if (DestroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                m_currentHealth = m_maxHealth;
                RpcRespawn();
            }
        }
        health_display.value = m_currentHealth;
    }
    //Respawns char on death at spawn location on network
    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 m_spawnPoint = Vector3.zero;
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                m_spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = m_spawnPoint;
        }
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire(transform.right);
        }
        Movement();
    }

    [Command]
    void CmdFire(Vector3 forward)
    {
        GameObject bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = forward * 6.0f;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 15f);
    }

    void Movement()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * ms, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.up * -ms, ForceMode.Impulse);
        }
#elif UNITY_IOS || UNITY_ANDROID
        /*
        //Button Movement Will be added here
        for (var touch : Touch in Input.touches) 
    {
        if (touch.phase == TouchPhase.Began) 
        {
            // Construct a ray from the current touch coordinates
            var ray = Camera.main.ScreenPointToRay (touch.position);
            if (Physics.Raycast (ray)) 
            {
                //Detect if hits button Up
                    //rb.AddForce(Vector3.up * ms, ForceMode.Impulse);
                //Detect of hits butotn Down
                    rb.AddForce(Vector3.up * ms, ForceMode.Impulse);
            }
        }
    }*/
#endif
    }
}
