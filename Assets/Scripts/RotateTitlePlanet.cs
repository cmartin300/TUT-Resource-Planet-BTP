using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTitlePlanet : MonoBehaviour
{
    [SerializeField] Transform planet;
    [SerializeField] float rotationSpeed;


    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        planet.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
