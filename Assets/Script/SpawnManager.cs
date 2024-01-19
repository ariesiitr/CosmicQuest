using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
     public GameObject[] projectPrefab;
    public Vector3[] Position ;

    // private Vector3 Position3 =new Vector3(-415,(float)70.7,12);
    // private Vector3 Position4 =new Vector3(-415,(float)70.7,12);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandom",2f,5f);
    }

    // Update is called once per frame
    void Update()
    {

    
}

    void SpawnRandom(){
        int randomIndex = Random.Range (0,projectPrefab.Length);
        int randomIndex1 = Random.Range (0,projectPrefab.Length);
            
            Instantiate(projectPrefab[randomIndex],Position[randomIndex1]+transform.position,projectPrefab[randomIndex1].transform.rotation);
    }
}