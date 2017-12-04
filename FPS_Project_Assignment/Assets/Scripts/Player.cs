using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float ms;
    public float ds_speed;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public Camera cam;
    public int m_currentHealth;
    public int m_maxHealth;
    public bool DestroyOnDeath;
    public Slider HealthIndicator;
    public int m_Score;
    public Text score_Text;
    public GameObject EndGame;
    public Text DeathScore;

    //public Vector3 TransformClamp;

    // Use this for initialization
    void Awake()
    {
        gameObject.SetActive(true);

        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //Call Movement
        Movement();
        //Check IF fire is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
        //Updates Score Text field 
        score_Text.text = "SCORE: " + m_Score;
    }
    //Damage Function
    public void TakeDamage(int Amount)
    {
        m_currentHealth -= Amount;
        if (m_currentHealth <= 0)
        {
            DestroyOnDeath = true;
            if (DestroyOnDeath)
            {
                DeathScore.text = m_Score.ToString(); 
                EndGame.SetActive(true);
                gameObject.SetActive(false); 
            }
            else
            {
                m_currentHealth = m_maxHealth;
            }
        }
        HealthIndicator.value = m_currentHealth;
    }
    //Shooting Function
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;
        Destroy(bullet, 15f);
    }
    //Collision Detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Damage Ammount
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * ms, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.up * -ms, ForceMode.Impulse);
        }
    }
}
