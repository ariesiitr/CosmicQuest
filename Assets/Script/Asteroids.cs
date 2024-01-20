using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // The minimum and maximum force values
    public float minForce = 5f;
    public float maxForce = 10f;

    // The Rigidbody component
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }
    void Update(){
        Invoke("ApplyRandomForce",10f);
        Debug.Log("Apply force");
    }
    // Method to apply a random force to the Rigidbody
    public void ApplyRandomForce()
    {
        // Generate a random direction
        Vector3 randomDirection = Random.onUnitSphere;

        // Generate a random force magnitude within the specified range
        float randomForceMagnitude = Random.Range(minForce, maxForce);

        // Apply the force to the Rigidbody in the random direction
        rb.AddForce(randomDirection * randomForceMagnitude, ForceMode.Impulse);
    }
}
