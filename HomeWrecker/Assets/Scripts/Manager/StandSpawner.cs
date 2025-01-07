using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandSpawner : MonoBehaviour
{
    [Header("BigSpawnPoints")]
    [SerializeField] Transform[] bigSpawnpoints90;
    //[SerializeField] Transform[] bigSpawnpointsMin90;
    [SerializeField] Transform[] bigSpawnpoints180;
    [SerializeField] Transform[] bigSpawnpointsNoRotate;

    [Header("SmallSpawnPoints")]
    [SerializeField] Transform[] smallSpawnpoints90;
    [SerializeField] Transform[] smallSpawnpointsMin90;
    [SerializeField] Transform[] smallSpawnpoints180;
    [SerializeField] Transform[] smallSpawnpointsNoRotate;

    [Header("Stands")]
    [SerializeField] GameObject[] bigStands;
    [SerializeField] GameObject[] smallStands;

    void Start()
    {
        SpawnBigStands();
        SpawnSmallStands();
    }

    void SpawnBigStands()
    {
        foreach (var spawnpoint in bigSpawnpointsNoRotate)
        {
            int randomSpawn = Random.Range(0, bigStands.Length);

            GameObject stand = Instantiate(bigStands[randomSpawn], spawnpoint.position, Quaternion.identity);

            if(randomSpawn == 3)
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        
        // For if bigSpawnpoints ever get a 90 degree angle
        // foreach (var spawnpoint in bigSpawnpointsMin90)
        // {
        //     int randomSpawn = Random.Range(0, bigStands.Length + 1);

        //     GameObject stand = Instantiate(bigStands[randomSpawn], spawnpoint.position, Quaternion.identity);
        //     if(randomSpawn == 3)
        //     {
        //         stand.transform.rotation = Quaternion.Euler(0, 180, 0);
        //     }
        //     else
        //     {
        //         stand.transform.rotation = Quaternion.Euler(0, -90, 0);              
        //     }
        // }

        foreach(var spawnpoint in bigSpawnpoints90)
        {
            int randomSpawn = Random.Range(0, bigStands.Length);

            GameObject stand = Instantiate(bigStands[randomSpawn], spawnpoint.position, Quaternion.identity);
            
            if(randomSpawn == 3)
            {
                stand.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);              
            }
        }

        foreach(var spawnpoint in bigSpawnpoints180)
        {
            int randomSpawn = Random.Range(0, bigStands.Length);

            GameObject stand = Instantiate(bigStands[randomSpawn], spawnpoint.position, Quaternion.identity);
            
            if(randomSpawn == 3)
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);    
            }
        }
    }

        void SpawnSmallStands()
    {
        foreach (var spawnpoint in smallSpawnpointsNoRotate)
        {
            int randomSpawn = Random.Range(0, smallStands.Length);

            GameObject stand = Instantiate(smallStands[randomSpawn], spawnpoint.position, Quaternion.identity);

            if(randomSpawn == 2)
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }

        foreach (var spawnpoint in smallSpawnpointsMin90)
        {
            int randomSpawn = Random.Range(0, smallStands.Length);

            GameObject stand = Instantiate(smallStands[randomSpawn], spawnpoint.position, Quaternion.identity);
            
            if(randomSpawn == 2)
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);      
            }
        }

        foreach(var spawnpoint in smallSpawnpoints90)
        {
            int randomSpawn = Random.Range(0, smallStands.Length);

            GameObject stand = Instantiate(smallStands[randomSpawn], spawnpoint.position, Quaternion.identity);
            
            if(randomSpawn == 2)
            {
                stand.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);                 
            }
        }

        foreach(var spawnpoint in smallSpawnpoints180)
        {
            int randomSpawn = Random.Range(0, smallStands.Length);

            GameObject stand = Instantiate(smallStands[randomSpawn], spawnpoint.position, Quaternion.identity);
            
            if(randomSpawn == 2)
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);            
            }
        }
    }
}
