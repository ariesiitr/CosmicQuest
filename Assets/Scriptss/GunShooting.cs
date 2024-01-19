using System;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public GameObject Explosionprfab;
    public Transform gunEnd; // The position where the laser will originate
    public float gunRange = 50f; // The range of the laser
    public LineRenderer laserLine; // LineRenderer for the visual representation of the laser
    public float laserDuration = 0.5f; // Duration of the laser

    private float nextShootTime = 0f; // Time when the next shot can be fired

    void Update()
    {
        // Check if the trigger button is pressed on the right controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) && Time.time > nextShootTime)
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // Set the starting point of the laser at the gunEnd position
        laserLine.SetPosition(0, gunEnd.position);

        // Create a ray from the gunEnd position in the forward direction
        Ray ray = new Ray(gunEnd.position, gunEnd.forward);
        RaycastHit hit;

        // Check if the ray hits something within the gunRange
        if (Physics.Raycast(ray, out hit, gunRange))
        {
            // Set the end point of the laser at the hit point
            laserLine.SetPosition(1, hit.point);

            // Perform actions based on the hit object (you can customize this part)
            HandleHitObject(hit.collider.gameObject);
            if(hit.transform.gameObject.CompareTag("MainCamera")){

            }
            else
            {Destroy(hit.transform.gameObject);
                Explosion(hit);
            }
        }
        else
        {
            // If the ray doesn't hit anything, set the end point to the maximum range
            laserLine.SetPosition(1, gunEnd.position + gunEnd.forward * gunRange);
        }

        // Activate the LineRenderer
        laserLine.enabled = true;

        // Schedule the deactivation of the LineRenderer after the specified duration
        nextShootTime = Time.time + laserDuration;

        // Deactivate the LineRenderer after the specified duration
        Invoke("DeactivateLaser", laserDuration);
    }

    void DeactivateLaser()
    {
        // Deactivate the LineRenderer
        laserLine.enabled = false;
    }

    void HandleHitObject(GameObject hitObject)
    {
        // Add your logic here based on the hit object
        // For example, you can destroy the object, apply damage, etc.
        // For now, let's just print the name of the hit object.
        Debug.Log("Hit: " + hitObject.name);
    }
    // void Explosion(RaycastHit hit){
    //     Instantiate(Explosionprfab,hit.transform.position,Quaternion.identity);
    //     Invoke("DestroyExplosionPrfab",1f);
    // }
    // void DestroyExplosionPrfab(){
    //     Destroy(Explosionprfab.gameObject);
    // } // Assign your explosion prefab in the Unity Editor
void Explosion(RaycastHit hit)
{
    // Instantiate the explosion prefab and store the reference to the instance
    Instantiate(Explosionprfab, hit.transform.position, Quaternion.identity);

    // // Invoke the method to destroy the instantiated explosion after 1 second
    // Invoke("DestroyExplosionPrfab", 1f);
}

// void DestroyExplosionPrfab(GameObject explosionInstance)
// {
//     // Check if the explosion instance is not null before destroying it
//     if (explosionInstance != null)
//     {
//         Destroy(explosionInstance);
//     }
// }
}