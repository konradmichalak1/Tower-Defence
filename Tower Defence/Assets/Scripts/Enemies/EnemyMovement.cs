using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy movement controller - control all of the enemy movement methods.
/// </summary>
[RequireComponent(typeof(EnemyController))]
public class EnemyMovement : MonoBehaviour {

    /// <summary> Next waypoint. </summary>
    private Transform target;
    private int wavepointIndex = 0;
    /// <summary> This EnemyController class instance. </summary>
    private EnemyController enemy;

    private void Start()
    {
        enemy = GetComponent<EnemyController>();
        target = Waypoints.points[0];
    }

    private void Update()
    {
        //Move enemy object to specified position
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        //If enemy is free
        enemy.speed = enemy.startSpeed;
    }



    /// <summary> Set next waypoint to 'target' variable. </summary>
    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        target = Waypoints.points[++wavepointIndex];
    }

    /// <summary> If enemy reach the end of the path, subtract player lives. </summary>
    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
