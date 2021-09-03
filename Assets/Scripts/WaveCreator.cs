using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    public WaveManager m_wave;

    TDEnemy[] enemies;
    float[] enemyCount;

    List<TDEnemy> wave = new List<TDEnemy>();

    public Transform m_destination;

    bool m_EnemyClose = false;

    // Start is called before the first frame update
    void Start()
    {
        SetUpWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (wave.Count > 0)
        {
            if (!m_EnemyClose)
            {
                TDEnemy e = Instantiate(wave[0], transform.position, transform.rotation);
                e.m_Destination = m_destination;
                wave.Remove(wave[0]);
            }
        }
    }

    void SetUpWave()
    {
        enemies = m_wave.GetTypes();
        enemyCount = m_wave.GetCount();

        if (enemyCount.Length < enemies.Length)
        {
            Debug.LogError("Wave Failed, the count array must be the same size");
        }
        else
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                for (int j = 0; j < enemyCount[i]; j++)
                {
                    wave.Add(enemies[i]);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TDEnemy>() != null)
        {
            m_EnemyClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TDEnemy>() != null)
        {
            m_EnemyClose = false;
        }
    }
}
