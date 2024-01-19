using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    public float delay = 1f; // Delay before destruction

    void Start()
    {
        // Call the DestroyAfterDelay method with the specified delay
        DestroyAfterDelay();
    }

    void DestroyAfterDelay()
    {
        // Destroy the GameObject after the specified delay
        Destroy(gameObject, delay);
    }
}