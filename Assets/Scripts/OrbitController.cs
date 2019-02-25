using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public float orbitSpeed = 40;
    public float InitialOrbitSize = 7;
    public float shrinkSpeed = 2;
    public PlanetController[] planets;


    // Start is called before the first frame update
    void Start()
    {
        planets = GetComponentsInChildren<PlanetController>();

        InitialisePalnets();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * orbitSpeed * Time.deltaTime);
        ShrinkOrbit();
    }

    void InitialisePalnets()
    {
        foreach (PlanetController planet in planets)
        {
            planet.transform.localPosition = new Vector3(InitialOrbitSize, 0, 0);
        }
    }

    void ShrinkOrbit()
    {
        foreach (PlanetController planet in planets)
        {
            planet.transform.localPosition = planet.transform.localPosition - new Vector3(shrinkSpeed / 100, 0, 0);

            if(planet.transform.localPosition.x <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
