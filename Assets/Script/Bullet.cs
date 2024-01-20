using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed=2000f;
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
     scoreManager= GameObject.Find("ScoreManager").GetComponent<ScoreManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime);
        if(transform.position.z>-10){
            Destroy(gameObject);
        }
    }
     private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("MainCamera")){
            scoreManager.SubScore();
        }
    }

   
}
