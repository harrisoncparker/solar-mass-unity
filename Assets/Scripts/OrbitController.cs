using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    // Set Values
    private float initialOrbitSize = 7;
    private float shrinkSpeed = 16;
    private bool readyToGo = false;

    // Holder Values
    private PlanetController[] planets;
    private GameObject orbitLine;

    // Randomized Values
    //private Quaternion initialRotation;
    private float orbitSpeed;
    private Vector3 orbitDirection;

    public void initialise(float setInitialOrbitSize = 0)
    {
        initialOrbitSize = setInitialOrbitSize > 0 ? setInitialOrbitSize : initialOrbitSize;
        readyToGo = true;
        setRandomValues();
        InitialiseOrbitLine();
        InitialisePalnets();
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToGo)
        {
            transform.Rotate(orbitDirection * orbitSpeed * Time.deltaTime);
            ShrinkOrbit();
        }
    }

    // Set speed and direction ect to add variation
    void setRandomValues()
    {
        transform.Rotate(0,0, Random.Range(0, 360));
        orbitDirection = Random.Range(0, 2) == 1 ? Vector3.forward : Vector3.back;
        orbitSpeed = Random.Range(35, 45);
    }

    // Init planets 
    void InitialisePalnets()
    {
        planets = GetComponentsInChildren<PlanetController>();

        foreach (PlanetController planet in planets)
        {
            planet.transform.localPosition = new Vector3(initialOrbitSize, 0, 0);
        }
    }

    // The line showing the orbit
    void InitialiseOrbitLine()
    {
        orbitLine = this.transform.Find("OrbitLine").gameObject;
        float orbitLineScale = initialOrbitSize * 2;
        orbitLine.transform.localScale = new Vector3(orbitLineScale, orbitLineScale, 0);
    }

    // Shrink orbits
    void ShrinkOrbit()
    {
        float shrinkBy = shrinkSpeed / 100 * Time.deltaTime;

        // Increase orbit speed by a fraction of the origional
        orbitSpeed += (orbitSpeed / 50 * Time.deltaTime);

        foreach (PlanetController planet in planets)
        {
            // reduce planets distance from blackhole
            planet.transform.localPosition = planet.transform.localPosition - new Vector3(shrinkBy, 0, 0);

            // Remove planets when they have entered the black hole
            if (planet.transform.localPosition.x <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        // Reduce size of orbit line to stay with planets on orbit
        orbitLine.transform.localScale = orbitLine.transform.localScale - new Vector3(shrinkBy * 2, shrinkBy * 2, 0);
    }
}
