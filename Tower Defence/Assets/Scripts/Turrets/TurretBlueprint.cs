using System.Collections;
using UnityEngine;

/// <summary>
/// Turret blueprint has info about turret cost in shop.
/// It is used in Shop.cs class
/// </summary>
[System.Serializable] //Serializable describes Unity how to show information about object
public class TurretBlueprint {

    /// <summary>
    /// Turret prefab
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// Turret cost
    /// </summary>
    public int cost;
    /// <summary>
    /// Upgraded turret prefab
    /// </summary>
    public GameObject upgradedPrefab;
    /// <summary>
    /// Turret upgrade cost
    /// </summary>
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost/2;
    }
}
