using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] GameObject increaseobj;
    void Start()
    {
        increaseobj = GameObject.Find("Backgrounds").GetComponent<creatground>().increaseobj;
      new List<Transform>(transform.GetComponentsInChildren<Transform>()).FindAll(x => x.name.Contains("Cube")).ForEach(delegate (Transform tr) { Instantiate(increaseobj, tr.position, tr.rotation,tr
             );});
    }

    // Update is called once per frame
    
}
