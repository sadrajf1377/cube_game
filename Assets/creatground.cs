using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatground : MonoBehaviour
{
    public GameObject[] grounds;
    [SerializeField] Transform instpos;
    public GameObject increaseobj;
    private void Start()
    {
        grounds = GameObject.Find("Backgrounds").GetComponent<creatground>().grounds;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int j = Random.Range(0, 5);
            Instantiate(grounds[j], instpos.position, instpos.rotation);
        }
    }
}
