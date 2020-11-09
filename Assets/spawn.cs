using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;
    public int enemiesPerWave = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Spawn()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-6f, 6f), 7, 0), Quaternion.identity);
        }
       
    }
}
