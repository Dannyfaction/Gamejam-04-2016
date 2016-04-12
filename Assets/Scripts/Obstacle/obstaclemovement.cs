using UnityEngine;
using System.Collections;

public class obstaclemovement : MonoBehaviour {

    
    private float movespeed = 6;
    private float distance = 0;
    void Start()
    {
        Destroy(gameObject, 15f);
    }
	
	void Update () {
        distance += 6;
        if(distance > 10)
        {
            
            distance = 0;
        }
        transform.Translate(Vector3.right * Time.deltaTime * movespeed);
	 }
  

}
