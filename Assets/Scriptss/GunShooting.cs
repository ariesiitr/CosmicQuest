// GunShooting.cs

using UnityEngine;
using OculusSampleFramework;

public class GunShooting : MonoBehaviour
{
    public Material laserMaterial;
    public float laserWidth = 0.02f;
    public float laserMaxLength = 20f;

    private LineRenderer laserLine;
    private bool isShooting = false;

    void Start()
    {
        // Create a Line Renderer component for the laser
        laserLine = gameObject.AddComponent<LineRenderer>();
        laserLine.material = laserMaterial;
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
        laserLine.useWorldSpace = true;
    }

    void Update()
    {
        // Check if the trigger button is pressed on the right controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isShooting = true;
            Debug.Log("Shoot");
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isShooting = false;
            laserLine.positionCount = 0; // Clear the laser when not shooting
        }

        // If shooting, update the laser beam
        if (isShooting)
        {
            UpdateLaserBeam();
        }
    }

    void UpdateLaserBeam()
    {
        RaycastHit hit;
        Vector3 startPoint = transform.position;
        Vector3 forwardDirection = transform.forward;

        // Cast a ray to detect the hit point
        if (Physics.Raycast(startPoint, forwardDirection, out hit, laserMaxLength))
        {
            // If hit, set the end point of the laser to the hit point
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, startPoint);
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            // If not hit, set the end point of the laser to the maximum length
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, startPoint);
            laserLine.SetPosition(1, startPoint + forwardDirection * laserMaxLength);
        }
    }
}