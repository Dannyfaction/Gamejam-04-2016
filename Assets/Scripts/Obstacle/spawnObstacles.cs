using UnityEngine;
using System.Collections;

public class spawnObstacles : MonoBehaviour {

    public GameObject[] spawnpoints;
    public GameObject Enemy;


    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("obsSpawn1");
    }

   
    void Update()
    {

           
        Invoke("spawnenemies", 0.5f);
    }
    void spawnenemies()
    {
        

        for(int i = 0; i < spawnpoints.Length; i++)
        {
            int spawnpos = i;

            Instantiate(Enemy, spawnpoints[spawnpos].transform.position, spawnpoints[i].gameObject.transform.rotation);
            CancelInvoke();
        }
    }
}

