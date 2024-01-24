using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrates : MonoBehaviour
{
    
    public GameObject crate1;
    public GameObject crate2;
    bool shouldspawn =true;

    void Spawncrate(){
    Instantiate(crate1,new Vector3(Random.Range(-4.45f,4.45f),Random.Range(-4.45f,4.45f) , 0),Quaternion.identity);
    shouldspawn = true;

    }

    void Update(){
    if(shouldspawn){
        Invoke("Spawncrate",5);
        shouldspawn=false;
    }
    }
}
