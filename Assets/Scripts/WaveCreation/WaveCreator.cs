using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class WaveCreator : MonoBehaviour
{
    public WaveManager[] m_waves;

    WaveManager m_currentWave;

    TDEnemy[] enemies;
    float[] enemyCount;

    List<TDEnemy> wave = new List<TDEnemy>();

    public Transform m_destination;

    float maxTimer = 1.5f;
    float timer;

    public int waveIndex;

    public bool WavePlaying = false;

    public bool spawnsFinshed = false;

    public GameObject m_fog;
    public SkipTravel m_travelButton;
    public int m_unlockRound;

    //Using this to monitor later spawns
    public int roundPenalty = 0;
    private int penaltyCount = 0;

    public WaveAffIcons m_waveIcon;
    public WaveAffIcons m_groundWaveIcon;

    public float DistanceMultiplier;

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
                else
                {
                    spawnsFinshed = true;
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
                e.m_health *= DistanceMultiplier;
                wave.Remove(wave[0]);
                timer = maxTimer;
            }
        }
        else
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

            if (go.Length == 0)
            {
                if (waveIndex == m_unlockRound)
                {
                    if (m_travelButton != null)
                    {
                        m_travelButton.gameObject.GetComponent<Image>().enabled = true;
                    }

                    if (m_fog != null)
                    {
                        m_fog.SetActive(false);
                    }
                }

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
            m_groundWaveIcon.GetNextAffinity();
            m_waveIcon.GetNextAffinity();
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

        m_groundWaveIcon.GetNextAffinity();
        m_waveIcon.GetNextAffinity();
    }

    public void StartWave()
    {
        WavePlaying = true;
    }

    public affinity.Affinity GetWaveAffinity()
    {
        if(wave.Count > 0)
        {
            return wave[wave.Count - 1].m_affinity;
        }

        return 0;
    }

    public bool EmptyWaveAffinity()
    {
        if(wave.Count == 0)
        {
            return true;
        }

        return false;
    }
}
