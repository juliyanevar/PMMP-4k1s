using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal Other;
    public Camera PortalView;

    private void Start()
    {
        Other.PortalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = Other.PortalView.targetTexture;
    }
    
    private void Update()
    {
        // Position
        Vector3 lookerPosition = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        lookerPosition = -lookerPosition;
        PortalView.transform.localPosition = lookerPosition;

        // Rotation
        Quaternion difference = transform.rotation * Quaternion.Inverse(Other.transform.rotation * Quaternion.Euler(180,180,0));
        PortalView.transform.rotation = difference * Camera.main.transform.rotation;

        // Clipping
        PortalView.nearClipPlane = lookerPosition.magnitude;
    }
}
