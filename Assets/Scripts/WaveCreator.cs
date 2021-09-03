using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    public WaveManager m_wave;

    TDEnemy[] enemies;
    float[] enemyCount;

    List<TDEnemy> wave = new List<TDEnemy>();
    // Start is called before the first frame update
    void Start()
    {
        enemies = m_wave.GetTypes();
        enemyCount = m_wave.GetCount();

        if(enemyCount.Length < enemies.Length)
        {
            Debug.LogError("Wave Failed, the count array must be the same size");
        } else
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
