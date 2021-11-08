using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            rend.material.color = Color.green;
        }

        if (Input.GetKey(KeyCode.R))
        {
            rend.material.color = Color.red;
        }

        if (Input.GetKey(KeyCode.B))
        {
            rend.material.color = Color.blue;
        }
    }
}
