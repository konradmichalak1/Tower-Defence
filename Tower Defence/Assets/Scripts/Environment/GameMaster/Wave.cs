using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave {
    /// <summary>
    /// Enemy object.
    /// </summary>
    public GameObject enemy;
    /// <summary>
    /// Amount of enemies that will spawn in that wave.
    /// </summary>
    public int count;
    /// <summary>
    /// Amount of time. How many enemies spawns per seconds: 5 means 5 enemies per second.
    /// </summary>
    public float rate;

}
