using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSpawner : MonoBehaviour
{
    public Transform orbitPrefab;
    public float timeBetweenSpawns = 6;
    public List<float> initialDistances;
    private float currentDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (float distance in initialDistances)
        {
            // set orbit distance to be one defined in initalDistances
            currentDistance = distance;
            SpawnOrbit();
        }
        // Reset orbit distance to not be effected by this class
        currentDistance = 0;
        InvokeRepeating("SpawnOrbit", timeBetweenSpawns, timeBetweenSpawns);
    }

    void SpawnOrbit()
    {
        Transform newOrbit = Instantiate(orbitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newOrbit.GetComponent<OrbitController>().initialise(currentDistance);
    }
}
