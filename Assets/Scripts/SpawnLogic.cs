using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{

    [SerializeField] int PackageSpawnCount = 5;
    [SerializeField] int BoostSpawnCount = 5;
    [SerializeField] int MaxUsedSpawns = 15;
    [SerializeField] GameObject PackagePrefab;
    [SerializeField] GameObject BoostPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("PackageSpawn"); //yeah. im really doing this

        for (int i = 0; i < PackageSpawnCount; i++)
        {
            while (true)
            {
                GameObject spawnpoint = spawns[Random.Range(0, spawns.Length - 1)]; //get random spawn
                if (!spawnpoint.GetComponent<SpawnPoint>().used)
                {
                    Instantiate(PackagePrefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
                    spawnpoint.GetComponent<SpawnPoint>().used = true;
                    break;
                }
            }
        }

        for (int i = 0; i < BoostSpawnCount; i++)
        {
            while (true)
            {
                GameObject spawnpoint = spawns[Random.Range(0, spawns.Length - 1)]; //get random spawn
                if (!spawnpoint.GetComponent<SpawnPoint>().used)
                {
                    Instantiate(BoostPrefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
                    spawnpoint.GetComponent<SpawnPoint>().used = true;
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPackage()
    {
        
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("PackageSpawn"); //yeah. im really doing this
        while (true)
        {
            GameObject spawnpoint = spawns[Random.Range(0, spawns.Length - 1)]; //get random spawn
            if (!spawnpoint.GetComponent<SpawnPoint>().used)
            {
                Instantiate(PackagePrefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
                spawnpoint.GetComponent<SpawnPoint>().used = true;
                break;
            }
        }

        CheckUsed();
    }

    public void SpawnBoost()
    {
        
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("PackageSpawn"); //yeah. im really doing this
        while (true)
        {
            GameObject spawnpoint = spawns[Random.Range(0, spawns.Length - 1)]; //get random spawn
            if (!spawnpoint.GetComponent<SpawnPoint>().used)
            {
                Instantiate(BoostPrefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
                spawnpoint.GetComponent<SpawnPoint>().used = true;
                break;
            }
        }

        CheckUsed();
    }

    public void CheckUsed()
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("PackageSpawn"); //yeah. im really doing this

        int usedcount = 0;
        foreach (GameObject g in spawns)
        { //get number of used spawnpoints
            if (g.GetComponent<SpawnPoint>().used == true)
            {
                usedcount++;
            }
        }

        if (usedcount > MaxUsedSpawns)
        { //refresh used spawnpoints
            foreach (GameObject g in spawns) 
            {
                g.GetComponent<SpawnPoint>().used = false;
            }
        }
    }
}
