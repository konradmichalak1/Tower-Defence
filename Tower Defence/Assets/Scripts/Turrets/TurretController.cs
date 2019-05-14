using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All Turrets.prefab script.
/// </summary>
public class TurretController : MonoBehaviour {

    

    /// <summary> Closest enemy position. </summary>
    private Transform target;
    /// <summary> Closest enemy object </summary>
    private EnemyController targetEnemy;

    /// <summary> Shooting range. </summary>
    [Header("General")]
    public string turretName;

    public float range = 15f;

    /// <summary>Turret rotate speed. </summary>
    public float turnSpeed = 10f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    /// <summary>Frequency of turrets shooting - 1 means 1 bullet/s; 2 means 2 bullets/s </summary>
    public float fireRate = 1f;
    /// <summary> Shoot timer. </summary>
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    /// <summary> Damage dealt every second. </summary>
    public int damageOverTime = 30;
    /// <summary> Slow power. 1 - enemy completely freezed, 0 - enemy has normal speed. </summary>
    public float slowPercentage = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]
    /// <summary> Enemy tag in Unity </summary>
    public string enemyTag = "Enemy";
    /// <summary> Part of turret model that is supposed to rotate - in that case that is: PartToRotate that is parent of turret Head </summary>
    public Transform partToRotate;

    public Transform firePoint;

	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //Starts UpdateTarget() fuction every specified time

        //Set turret stats from global stats
        range = TurretsStats.GetTurretRange(turretName);
        fireRate = TurretsStats.GetTurretFireRate(turretName);
        damageOverTime = TurretsStats.GetTurretDamageOverTime(turretName);
        slowPercentage = TurretsStats.GetTurretSlowPercentage(turretName);

    }

    /// <summary>
    /// Searches for the closest enemy and focus turret on it
    /// </summary>
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyController>();
        }
        else
        {
            target = null;
        }
    }

    void Update () {

        if (target == null)
        {
            if(useLaser && lineRenderer.enabled)
            {
                impactEffect.Stop();
                lineRenderer.enabled = false;
                impactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();

        if(useLaser)
        {
            Laser();
        }
        else
        {
            //Fires
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime; //decrease fireCountdown
        }

	}

    /// <summary>
    /// Changes turret rotation, when focused on enemy.
    /// </summary>
    private void LockOnTarget()
    {
        //Target lock on - Calculates angle between turret and the closest enemy and set turret rotation
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);
    }

    /// <summary>
    /// Shoots to enemy.
    /// </summary>
    private void Shoot()
    {
        GameObject _bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletController bullet = _bullet.GetComponent<BulletController>();

        if(bullet != null)
        {
            bullet.ChaseEnemy(target);
        }
    }

    /// <summary>
    /// Strikes enemy by laser and generates laser effect/parcticle system effect.
    /// </summary>
    private void Laser()
    {
        //Making sure that we are not lasering enemy that is not alive.
        if (!targetEnemy.isAlive)
            return;

        //Damaging
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);

        //Slowing
        targetEnemy.Slow(slowPercentage);


        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        //Generates laser-line rendered.
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        //Generates impact effect
        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); // Shows range circle inside Unity editor
    }
}
