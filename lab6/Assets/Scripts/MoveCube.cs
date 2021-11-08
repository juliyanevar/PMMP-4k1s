using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveCube : MonoBehaviour, IPointerClickHandler
{
    Rigidbody rb;
    public float force;
    public InputField field;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!float.TryParse(field.text, out force))
        {
            force = 0.1f;
        }
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        rb.AddForce(0, 0, force, ForceMode.Impulse);
    }
}
