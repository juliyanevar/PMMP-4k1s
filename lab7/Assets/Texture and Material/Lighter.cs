using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject Light;
    void Start()
    {
        Light.SetActive(false);
    }


    void OnTriggerEnter(Collider col)
    {
		Debug.Log(col.tag);
        if (col.gameObject.tag == "Player")
        {
            Light.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Light.SetActive(false);
        }
    }
}
