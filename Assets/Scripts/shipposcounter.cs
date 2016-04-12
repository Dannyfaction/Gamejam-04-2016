using UnityEngine;
using System.Collections;

public class shipposcounter : MonoBehaviour {
    public float poscounter = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("poscounttag"))
        {
            poscounter += 1;
        }
    }
}
