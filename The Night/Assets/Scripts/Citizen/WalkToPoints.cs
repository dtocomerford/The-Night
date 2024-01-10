using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPoints : MonoBehaviour
{
    public GameObject[] waypoints;

    [Tooltip("The minimum distance the citizen has to be from the target before its classed as arrived")]
    public float minDistanceFromTarget;
    private GameObject lastTarget = null;

    //Check again
    public GameObject GetWaypoint()
    {
        int index = Random.Range(0, waypoints.Length);
        GameObject newTarget = waypoints[index];
        if (newTarget == lastTarget)
        {
            newTarget = waypoints[index + 1 % waypoints.Length];
        }

        lastTarget = newTarget;
        return newTarget;
    }

    public bool AtTarget(GameObject target)
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) < minDistanceFromTarget)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
