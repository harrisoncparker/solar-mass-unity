using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSpawner : MonoBehaviour
{
    public Transform orbitPrefab;
    public float timeBetweenSpawns = 5;
    public List<float> initialDistances;

    // Start is called before the first frame update
    void Start()
    {
        foreach(float distance in initialDistances)
        {
            Transform newOrbit = Instantiate(orbitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newOrbit.GetComponent<OrbitController>().initialise(distance);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
