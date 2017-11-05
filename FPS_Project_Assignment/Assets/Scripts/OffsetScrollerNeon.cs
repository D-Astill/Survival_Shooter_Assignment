using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrollerNeon : MonoBehaviour {

    public float scrollSpeed = 0.5F;
    public Renderer rend;
    public float startTime;
    public bool reverse;
    public float offset;

    void Start()
    {
        startTime = 0f;
    }
    void Update()
    {
        startTime += Time.deltaTime;
        rend = GetComponent<Renderer>();
        if (startTime >= 10f && reverse == false)
        {
            reverse = true;
            startTime = 0;
        }
        if (startTime >= 10f && reverse == true)
        {
            reverse = false;
            startTime = 0;
        }
        offset = Time.time * scrollSpeed;
        if (reverse == true)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        else
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
            
        }
       

    }
}
