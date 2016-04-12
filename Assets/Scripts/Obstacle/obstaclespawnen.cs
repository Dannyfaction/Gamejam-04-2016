using UnityEngine;
using System.Collections;

public class obstaclespawnen : MonoBehaviour {
   
    
    public GameObject obsacle;
    

    void Start()
    {
        
    }

    // Update 
    void Update()
    {
            InvokeRepeating("spawnObstacle", 1, 1f);
    }
    void spawnObstacle()
    {
        Instantiate(obsacle);
        CancelInvoke();
    }
}