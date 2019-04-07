using UnityEngine;

/// <summary>
/// Waypoints object script (as childrens contain array of Waypoint.prefab)
/// </summary>
public class Waypoints : MonoBehaviour {
    
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount]; //zwraca liczbę wszystkich obiektów dzieci, czyli Waypointów
        for(int i =0; i< points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
