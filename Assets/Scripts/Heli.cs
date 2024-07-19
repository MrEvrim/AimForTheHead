using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli : MonoBehaviour
{
    public GameObject heli;
    public GameObject tailRaptor;
    public GameObject topRaptor;
    private float rotationSpeed = 5.0f;
    private float rotationSpeedHeli = 0.05f;
    void Update()
    {
        Raptor();
        HeliRotation();
    }
    void Raptor()
    {
        topRaptor.transform.Rotate(Vector3.up, rotationSpeed);
        tailRaptor.transform.Rotate(Vector3.right, rotationSpeed);
    }
    void HeliRotation()
    {
        heli.transform.Rotate(Vector3.up, rotationSpeedHeli);
    }
}
