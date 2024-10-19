using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    [SerializeField] GameObject followobject;
    Quaternion direction;
    [SerializeField]Vector3 offset;
    [SerializeField] Vector3 delaytime;
   public float speed;
    void Awake()
    {
        transform.rotation = followobject.transform.rotation;
        transform.position = followobject.transform.position;
       
    }

    // Update is called once per frame
    private void Update()
    {
        //  speed += 0.05f*Time.deltaTime;


      GetComponent<Rigidbody>().velocity=new Vector3(0,0, followobject.transform.parent.GetComponent<Rigidbody>().velocity.z);
      // transform.rotation = Quaternion.Lerp(transform.rotation, direction, Time.deltaTime * 30);
    }
}
