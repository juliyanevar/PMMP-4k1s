using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform tpLocation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "User")
        {
            if(tpLocation.tag == "Blue") other.gameObject.transform.position = tpLocation.transform.position+new Vector3 (0,0,-3);
            else other.gameObject.transform.position = tpLocation.transform.position+new Vector3 (0,0,3);            
        }
    }
}
