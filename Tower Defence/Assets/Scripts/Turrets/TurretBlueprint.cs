using System.Collections;
using UnityEngine;

/// <summary>
/// Turret blueprint has info about turret cost in shop.
/// It is used in Shop.cs class
/// </summary>
[System.Serializable] //Serializable describes Unity how to show information about object
public class TurretBlueprint {

    //Turret object
    public GameObject prefab;
    //Turret cost
    public int cost;
}
