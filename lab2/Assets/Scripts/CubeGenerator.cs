using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    MeshRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float minX = render.bounds.min.x;
        float maxX = render.bounds.max.x;
        float minZ = render.bounds.min.z;
        float maxZ = render.bounds.max.z;

        float newX = Random.Range(minX, maxX);
        float newZ = Random.Range(minZ, maxZ);
        float newY = gameObject.transform.position.y + 5;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cubb = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubb.transform.position = new Vector3(newX, newY, newZ);

            cubb.AddComponent<Rigidbody>();
        }
    }
}
