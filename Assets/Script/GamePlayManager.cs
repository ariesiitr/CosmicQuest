using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public GameObject spawnManagaer;
    public GameObject Asteroids;
    public GameObject Environment;
    public GameObject ParticleAsteroids;
    public GameObject Nebula;
    public GameObject Stars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other) {
         Debug.Log("Trigger collider entered the other collider!");
        if(other.CompareTag("MainCamera")){
            Invoke("SetspawnManagerActive",57.5f);
            Invoke("SetAsteroidsActive",27f);
            Invoke("SetNebulaActive",12f);
            gameObject.SetActive(false);
        }
    }
    void SetspawnManagerActive(){
        Stars.SetActive(true);
        Asteroids.SetActive(false);
        spawnManagaer.SetActive(true);
    }
    void SetAsteroidsActive(){
        Nebula.SetActive(false);
        
        Stars.SetActive(false);
        Asteroids.SetActive(true);
    }
    void SetNebulaActive(){
        Nebula.SetActive(true);
        ParticleAsteroids.SetActive(false);
    }
}

