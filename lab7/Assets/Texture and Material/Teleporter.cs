using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject objToTP;
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
            Debug.Log(other.gameObject.tag);
            Debug.Log("User"+other.gameObject.transform.rotation);
            if(tpLocation.tag == "Blue") other.gameObject.transform.position = tpLocation.transform.position+new Vector3 (0,0,-3);
            else other.gameObject.transform.position = tpLocation.transform.position+new Vector3 (0,0,3);            
        }
    }

    // public Teleporter Other;

    // private void Start()
    // {
        
    // }
    
    // private void Update()
    // {
        
    // }

    // private void OnTriggerStay(Collider other)
    // {
    //     float zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;
    //     Debug.Log("User "+other.transform.position);
    //     Debug.Log("Portal "+gameObject.transform.position);
    //     if (zPos < 1.2) Teleport(other.transform);
    // }

    // private void Teleport(Transform obj)
    // {
    //     // Position
    //     Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
    //     //localPos = -localPos;
    //     localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
    //     obj.position = Other.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);

    //     // Rotation
    //     Quaternion difference = Other.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(180, 180, 0));
    //     obj.rotation = difference * obj.rotation;
    // }

    //private void OnTriggerEnter(Collider other)
    //{
    //    other.gameObject.layer = 9;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    other.gameObject.layer = 8;
    //}
}
