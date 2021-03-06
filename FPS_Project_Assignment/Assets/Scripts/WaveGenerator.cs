﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WaveAction
{
    public string name;
    public float delay;
    public Transform prefab;
    public int spawnCount;
    public string message;
}

[System.Serializable]
public class Wave
{
    public string name;
    public List<WaveAction> actions;
}


public class WaveGenerator : MonoBehaviour
{
    public float difficultyFactor = 0.9f;
    public List<Wave> waves;
    private Wave m_CurrentWave;
    public Wave CurrentWave { get { return m_CurrentWave; } }
    private float m_DelayFactor = 1.0f;
    public Vector3 SpawnPos;


    IEnumerator SpawnLoop()
    {
        m_DelayFactor = 1.0f;
        while (true)
        {
            foreach (Wave W in waves)
            {
                m_CurrentWave = W;
                foreach (WaveAction A in W.actions)
                {
                    if (A.delay > 0)
                        yield return new WaitForSeconds(A.delay * m_DelayFactor);
                    if (A.message != "")
                    {
                        print("Spawn Enemy");
                    }
                    if (A.prefab != null && A.spawnCount > 0)
                    {
                        for (int i = 0; i < A.spawnCount; i++)
                        {
                            SpawnPos = new Vector3(transform.position.x, Random.Range(-5, 5), transform.position.z);

                            GameObject.Instantiate(A.prefab, SpawnPos, Quaternion.identity);
                        }
                    }
                }
                yield return null;
            }
            m_DelayFactor *= difficultyFactor;
            yield return null;
        }
    }

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }
}