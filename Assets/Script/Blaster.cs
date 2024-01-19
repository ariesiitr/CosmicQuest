using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("SpawnRandom",0.5f,1.75f);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandom(){
        Instantiate(Bullet,transform.position,transform.rotation);
    }
}
