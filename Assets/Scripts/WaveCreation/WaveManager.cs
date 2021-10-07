using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "WaveCreation/WaveManager", order = 1)]
public class WaveManager : ScriptableObject
{
    //Set the enemies that appear in the wave
    [SerializeField] private TDEnemy[] enemyTypes;
    //Set the amount of enemies per enemy type
    [SerializeField] private float[] enemyTypeCount;

        /*for(int i = 0; i < enemyTypes.Length; i++)
        {
            for (int j = 0; j < enemyTypeCount[i]; j++)
            {
                m_wave.Add(enemyTypes[i]);
            }
        }*/

    public TDEnemy[] GetTypes()
    {
        return enemyTypes;
    }

    public float[] GetCount()
    {
        return enemyTypeCount;
    }
}
