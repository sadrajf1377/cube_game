using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreincrease : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //other.GetComponent<movement>().multiplier++;
            print("score increased");
        }
    }
}
