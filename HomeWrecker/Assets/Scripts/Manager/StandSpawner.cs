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

    [Header("Parent")]
    [SerializeField] Transform parent;

    void Start()
    {
        SpawnBigStands();
        SpawnSmallStands();
    }

    void SpawnBigStands()
    {
        int randomSpawnBig = Random.Range(0, bigStands.Length);

        foreach (var spawnpoint in bigSpawnpointsNoRotate)
        {
            GameObject stand = Instantiate(bigStands[randomSpawnBig], spawnpoint.position, Quaternion.identity);
            stand.transform.SetParent(parent);

            if(randomSpawnBig == 3)
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);
            }

            if(randomSpawnBig == 4 ||randomSpawnBig == 5)
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            if(randomSpawnBig >= bigStands.Length -1)
            {
                randomSpawnBig = 0;
            }
            else
            {
                randomSpawnBig++;
            }
        }

        // For if bigSpawnpoints ever get a 90 degree angle
        // foreach (var spawnpoint in bigSpawnpointsMin90)
        // {
        //     GameObject stand = Instantiate(bigStands[randomSpawnBig], spawnpoint.position, Quaternion.identity);
        //     stand.transform.SetParent(parent);
        //     if(randomSpawnBig == 3)
        //     {
        //         stand.transform.rotation = Quaternion.Euler(0, 180, 0);
        //     }

        
        //     if(randomSpawnBig == 4 ||randomSpawnBig == 5)
        //     {
        //         stand.transform.rotation = Quaternion.Euler(0, 0, 0);
        //     }
        //     else
        //     {
        //         stand.transform.rotation = Quaternion.Euler(0, -90, 0);              
        //     }

            // if(randomSpawnBig == bigStands.Length)
            // {
            //     randomSpawnBig = 0;
            // }else
            // {
            //     randomSpawnBig++;
            // }
        // }

        foreach(var spawnpoint in bigSpawnpoints90)
        {
            GameObject stand = Instantiate(bigStands[randomSpawnBig], spawnpoint.position, Quaternion.identity);
            stand.transform.SetParent(parent);
            
            if(randomSpawnBig == 3)
            {
                stand.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(randomSpawnBig == 4 || randomSpawnBig == 5)
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);              
            }

            if(randomSpawnBig >= bigStands.Length -1)
            {
                randomSpawnBig = 0;
            }else
            {
                randomSpawnBig++;
            }
        }

        foreach(var spawnpoint in bigSpawnpoints180)
        {
            GameObject stand = Instantiate(bigStands[randomSpawnBig], spawnpoint.position, Quaternion.identity);
            stand.transform.SetParent(parent);
            
            if(randomSpawnBig == 3)
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if(randomSpawnBig == 4 || randomSpawnBig == 5 || randomSpawnBig == 11)
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);    
            }

            if(randomSpawnBig >= bigStands.Length -1)
            {
                randomSpawnBig = 0;
            }else
            {
                randomSpawnBig++;
            }
        }
    }

    void SpawnSmallStands()
    {
        int randomSpawnSmall = Random.Range(0, smallStands.Length);

        foreach (var spawnpoint in smallSpawnpointsNoRotate)
        {
            GameObject stand = Instantiate(smallStands[randomSpawnSmall], spawnpoint.position, Quaternion.identity);
            stand.transform.SetParent(parent);

            if(randomSpawnSmall == 2 || randomSpawnSmall == 12)
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if(randomSpawnSmall == 3 || randomSpawnSmall == 4 || randomSpawnSmall == 5 || randomSpawnSmall == 6 || randomSpawnSmall == 7 || randomSpawnSmall == 8 || randomSpawnSmall == 9 || randomSpawnSmall == 10 || randomSpawnSmall == 11)
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            if(randomSpawnSmall >= smallStands.Length -1)
            {
                randomSpawnSmall = 0;
            }else
            {
                randomSpawnSmall++;
            }
        }

        foreach (var spawnpoint in smallSpawnpointsMin90)
        {
            GameObject stand = Instantiate(smallStands[randomSpawnSmall], spawnpoint.position, Quaternion.identity);
            stand.transform.SetParent(parent);
            
            if(randomSpawnSmall == 2 || randomSpawnSmall == 12)
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(randomSpawnSmall == 3 || randomSpawnSmall == 4 || randomSpawnSmall == 5 || randomSpawnSmall == 6 || randomSpawnSmall == 7 || randomSpawnSmall == 8 || randomSpawnSmall == 9 || randomSpawnSmall == 10 || randomSpawnSmall == 11)
            {
                stand.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);      
            }

            if(randomSpawnSmall >= smallStands.Length -1)
            {
                randomSpawnSmall = 0;
            }else
            {
                randomSpawnSmall++;
            }
        }

        foreach(var spawnpoint in smallSpawnpoints90)
        {
           GameObject stand = Instantiate(smallStands[randomSpawnSmall], spawnpoint.position, Quaternion.identity);
           stand.transform.SetParent(parent);
            
            if(randomSpawnSmall == 2 || randomSpawnSmall == 12)
            {
                stand.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(randomSpawnSmall == 3 || randomSpawnSmall == 4 || randomSpawnSmall == 5 || randomSpawnSmall == 6 || randomSpawnSmall == 7 || randomSpawnSmall == 8 || randomSpawnSmall == 9 || randomSpawnSmall == 10 || randomSpawnSmall == 11)
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);                 
            }

            if(randomSpawnSmall >= smallStands.Length -1)
            {
                randomSpawnSmall = 0;
            }else
            {
                randomSpawnSmall++;
            }
        }

        foreach(var spawnpoint in smallSpawnpoints180)
        {
            GameObject stand = Instantiate(smallStands[randomSpawnSmall], spawnpoint.position, Quaternion.identity);
            stand.transform.SetParent(parent);
            
            if(randomSpawnSmall == 2 || randomSpawnSmall == 12)
            {
                stand.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if(randomSpawnSmall == 3 || randomSpawnSmall == 4 || randomSpawnSmall == 5 || randomSpawnSmall == 6 || randomSpawnSmall == 7 || randomSpawnSmall == 8 || randomSpawnSmall == 9 || randomSpawnSmall == 10 || randomSpawnSmall == 11)
            {
                stand.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                stand.transform.rotation = Quaternion.Euler(0, 180, 0);            
            }

            if(randomSpawnSmall >= smallStands.Length -1)
            {
                randomSpawnSmall = 0;
            }else
            {
                randomSpawnSmall++;
            }
        }
    }

    public void SpawnStandsExternal()
    {
        SpawnBigStands();
        SpawnSmallStands();
    }
}
