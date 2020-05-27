
using System;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private CircleCollider2D sensorColl;

    private List<Character> sightedObjects = new List<Character>();

    public Action<Character> OnSight;
    public Action<Character> OnLoseOfSight;

    public List<Character> SightedObjects => sightedObjects;

    private void Awake()
    {
        sensorColl = GetComponent<CircleCollider2D>();
    }

    public void SetRange(float range)
    {
        sensorColl.radius = range;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Character detectable = other.GetComponent<Character>();
        if (detectable != null)
        {
            SightedObjects.Add(detectable);
            OnSight?.Invoke(detectable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Character detectable = other.GetComponent<Character>();
        if (detectable != null)
        {
            SightedObjects.Remove(detectable);
            OnLoseOfSight?.Invoke(detectable);
        }
    }
}
