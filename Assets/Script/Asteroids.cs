using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // The minimum and maximum force values
    public float minForce = 5f;
    public float maxForce = 10f;
    ScoreManager scoreManager;
    GunShooting gunShooting;

    // The Rigidbody component
    private Rigidbody rb;

    void Start()
    {
        scoreManager= GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        gunShooting= GameObject.Find("Gun").GetComponent<GunShooting>();
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
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("MainCamera")){
            Debug.Log("Destroying object!");
           scoreManager.SubScore();
           Destroy(gameObject); 
           gunShooting.Explosion2(transform.position);
        }
    }
}
