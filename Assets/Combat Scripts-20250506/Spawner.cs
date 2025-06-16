using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject Skeletonprefab;
    public int number;
    public float SpawnRadius;
    public bool SpawnOnStart = true;
    public bool ChaserSpawn = true;
    public PlayerData playerdata;
    

    // Start is called before the first frame update
    void Start()
    {
        if (SpawnOnStart)
        {
            SpawnAll();
            
        }
        
        this.GetComponent<Collider>().enabled = false;
    }

    void SpawnAll()
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 randoPoint = this.transform.position + Random.insideUnitSphere * SpawnRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randoPoint, out hit, 10.0f, NavMesh.AllAreas))
            {
                Instantiate(Skeletonprefab, randoPoint, Quaternion.identity);
                //playerdata.Chasers = playerdata.Chasers + 1;
            }          
            
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (ChaserSpawn)
        {
            if(playerdata.Chasers <= 0)
            {
                for (int i = 0; i < number; i++)
                {
                    Vector3 randoPoint = this.transform.position + Random.insideUnitSphere * SpawnRadius;
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randoPoint, out hit, 10.0f, NavMesh.AllAreas))
                    {
                        Instantiate(Skeletonprefab, randoPoint, Quaternion.identity);
                       // playerdata.Chasers = playerdata.Chasers + 1;
                    }

                }
            }
        }
        
    }
}
