using System.Collections.Generic;
using UnityEngine;

public class WayPoints : AbstractSingleton<WayPoints>
{
    public List<Transform> waypoints = new List<Transform>();
    protected override void Awake()
    {
        base.Awake();

        GameObject waypointContainer = GameObject.Find("WayPointContainer");
        foreach (Transform child in waypointContainer.transform)
        {
            waypoints.Add(child);
        }
    }
}
