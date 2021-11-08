using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    float _speed;

    void Start()
    {
        _speed = -0.25f; 
    }

    void Update()
    {
        if (transform.position.x > 33)
        {
            _speed = -0.25f; 
        }
        if (transform.position.x < -16)
        {
            _speed = 0.25f; 
        }
        transform.position = new Vector3(transform.position.x + _speed, transform.position.y, transform.position.z);
    }
}
