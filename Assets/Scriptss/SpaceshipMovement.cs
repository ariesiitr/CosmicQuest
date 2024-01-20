// SpaceshipMovement.cs

using UnityEngine;
using OculusSampleFramework;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 5f;
    public float xrange=20f;

    void Update()
    {
        // Get input from the left controller thumbstick
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;

        // Move the spaceship left and right
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        
        if(transform.position.x < -xrange){
            transform.position= new Vector3(-xrange, transform.position.y,transform.position.z );
        }
    
      if(transform.position.x > xrange){
            transform.position = new Vector3(xrange, transform.position.y,transform.position.z );
        }
    }
}
             