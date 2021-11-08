using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public bool zooming;
    public float zoomSpeed;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        if (zooming)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            camera.transform.Translate(ray.direction * zoomDistance, Space.World);
        }
    }
}
