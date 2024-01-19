using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float amplitude = 5.0f;
    public float frequency = 5.0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (target == null)
        {
            Debug.LogError("Target (camera) not assigned in the inspector!");
            return;
        }

        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float newY = initialPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

private void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collision detected with: " + collision.gameObject.name);

    if (collision.gameObject.CompareTag("MainCamera"))
    {
        Debug.Log("Destroying object!");
        Destroy(gameObject);
    }
}

}
