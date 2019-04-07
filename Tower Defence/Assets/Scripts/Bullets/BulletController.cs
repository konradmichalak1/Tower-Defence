using UnityEngine;
/// <summary>
/// StandardBulle.prefab script
/// </summary>
public class BulletController : MonoBehaviour {

    /// <summary> Enemy object </summary>
    private Transform target;
    /// <summary> Bullet impact effect </summary>
    public GameObject impactEffect;


    public int damage = 50;
    public float speed = 70f;

    /// <summary> Bullet explosion range (Area of effect - AOE) </summary>
    public float explosionRadius = 0f;

    public void ChaseEnemy(Transform _target)
    {
        target = _target;
    }

    private void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(effectIns, 2f); //destroy effect instance after selected time

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    /// <summary> Harms only one found target </summary>
    /// <param name="enemy">Found target/enemy instance</param>
    private void Damage(Transform enemy)
    {
        EnemyController e = enemy.GetComponent<EnemyController>();
        if(e!= null)
        {
            e.TakeDamage(damage);
        }
    }

    /// <summary>
    /// Harms all enemies in specified explosion range
    /// </summary>
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
