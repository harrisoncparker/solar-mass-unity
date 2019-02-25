using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public float orbitSpeed = 40;
    public float InitialOrbitSize = 7;
    public float shrinkSpeed = 2;
    public PlanetController[] planets;
    public GameObject orbitLine;

    // Start is called before the first frame update
    void Start()
    {
        InitialiseOrbitLine();
        InitialisePalnets();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * orbitSpeed * Time.deltaTime);
        ShrinkOrbit();
    }

    // Init planets 
    void InitialisePalnets()
    {
        planets = GetComponentsInChildren<PlanetController>();

        foreach (PlanetController planet in planets)
        {
            planet.transform.localPosition = new Vector3(InitialOrbitSize, 0, 0);
        }
    }

    // The line showing the orbit
    void InitialiseOrbitLine()
    {
        orbitLine = this.transform.Find("OrbitLine").gameObject;
        float orbitLineScale = InitialOrbitSize * 2;
        orbitLine.transform.localScale = new Vector3(orbitLineScale, orbitLineScale, 0);
    }

    // Shrink orbits
    void ShrinkOrbit()
    {
        // Increase orbit speed by a fraction of the origional
        orbitSpeed += (orbitSpeed / 50 * Time.deltaTime);

        foreach (PlanetController planet in planets)
        {
            // reduce planets distance from blackhole
            planet.transform.localPosition = planet.transform.localPosition - new Vector3(shrinkSpeed / 1000, 0, 0);

            // Remove planets when they have entered the black hole
            if (planet.transform.localPosition.x <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        // Reduce size of orbit line to stay with planets on orbit
        orbitLine.transform.localScale = orbitLine.transform.localScale - new Vector3(shrinkSpeed / 500, shrinkSpeed / 500, 0);
    }
}
