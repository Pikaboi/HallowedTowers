using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    public WaveManager[] m_waves;

    WaveManager m_currentWave;

    TDEnemy[] enemies;
    float[] enemyCount;

    List<TDEnemy> wave = new List<TDEnemy>();

    public Transform m_destination;

    float maxTimer = 0.5f;
    float timer;

    public int waveIndex;

    public bool WavePlaying = false;

    public bool spawnsFinshed = false;

    //Using this to monitor later spawns
    public int roundPenalty = 0;
    private int penaltyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        waveIndex = 0;
        m_currentWave = m_waves[waveIndex];
        SetUpWave();
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (WavePlaying)
        {
            if (penaltyCount != roundPenalty)
            {
                penaltyCount++;
                WavePlaying = false;
            } else if (m_currentWave == null)
            {
                WavePlaying = false;
                waveIndex++;
                if (waveIndex < m_waves.Length)
                {
                    m_currentWave = m_waves[waveIndex];
                    SetUpWave();
                }
            }
            else
            {
                SpawnWaves();
            }
        }
    }

    void SpawnWaves()
    {
        timer -= Time.deltaTime;
        if (wave.Count > 0)
        {
            if (timer <= 0.0f)
            {
                TDEnemy e = Instantiate(wave[0], transform.position, transform.rotation);
                e.m_Destination = m_destination;
                wave.Remove(wave[0]);
                timer = maxTimer;
            }
        }
        else
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

            if (go.Length == 0)
            {
                waveIndex++;
                if (waveIndex < m_waves.Length)
                {
                    m_currentWave = m_waves[waveIndex];
                    SetUpWave();
                }
                else
                {
                    spawnsFinshed = true;
                }
                WavePlaying = false;
            }
        }
    }

    void SetUpWave()
    {
        if (m_currentWave == null)
        {
            return;
        }

        enemies = m_currentWave.GetTypes();
        enemyCount = m_currentWave.GetCount();

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

    public void StartWave()
    {
        WavePlaying = true;
    }
}
