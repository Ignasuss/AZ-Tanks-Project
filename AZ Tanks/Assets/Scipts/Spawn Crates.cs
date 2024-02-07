using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnCrates : MonoBehaviour
{
    
    public GameObject crate1;
    public GameObject crate2;
    bool shouldspawn =true;

    void Spawncrate(){
    Instantiate(new System.Random().Next(2)==0?crate1:crate2,new Vector3(UnityEngine.Random.Range(-4.45f,4.45f), UnityEngine.Random.Range(-4.45f,4.45f) , 0),Quaternion.identity);
    shouldspawn = true;

    }

    void Update(){
    if(shouldspawn){
        Invoke("Spawncrate",10);
        shouldspawn=false;
    }
    }
}
