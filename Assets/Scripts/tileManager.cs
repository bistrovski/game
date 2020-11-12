﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public GameObject[] terrains;
    public float zSpawn = 0;
    public float terrainLength = 50;
    public int numberOfTerrains = 1;
    public Transform playerTransform;
    private List <GameObject> listOfTerrains = new List<GameObject>();
    void Start()
    {
        for(int i = 0; i<numberOfTerrains;i++)
        {
            SpawnTerrain(0);            
        }
    }


    void Update()
    {
        if(playerTransform.position.z > zSpawn - (terrainLength)) // infinity terrain and delete terrains which player crossed
        {
            SpawnTerrain(0);  
            DeleteTerrain();          
        }       
    }

    void SpawnTerrain(int terrain) // spawn new terrain
    {        
        GameObject ter = Instantiate(terrains[terrain],transform.forward * zSpawn, transform.rotation);
        listOfTerrains.Add(ter);
        zSpawn += terrainLength;
    }
    void DeleteTerrain()
    {
        Destroy(listOfTerrains[0]);
        listOfTerrains.RemoveAt(0);
    }
    
}
