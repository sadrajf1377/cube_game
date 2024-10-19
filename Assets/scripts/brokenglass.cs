using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenglass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(var item in GetComponentsInChildren<Rigidbody>())
        {
            item.AddForce((transform.position - item.gameObject.transform.position) *-3800+new Vector3(0,150,0));
            item.angularVelocity = new Vector3(30, 30, 30)*10;
        }
    }

   
}
