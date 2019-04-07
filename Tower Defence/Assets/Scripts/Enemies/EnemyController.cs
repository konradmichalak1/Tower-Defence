using UnityEngine;


/// <summary>
/// Enemy.prefab script
/// </summary>
public class EnemyController : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int moneyGain = 50;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    /// <summary> Deal specified amount of damage  </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health<= 0)
        {
            Die();
        }
    }

    /// <summary> 
    /// Calculates enemy movement speed depending on slowPercentage. 
    /// </summary>
    /// <param name="slowPercentage">Slow power. 1 - Completely freezed. 0 - Normal speed.</param>
    public void Slow(float slowPercentage)
    {
        speed = startSpeed * (1f - slowPercentage);
    }

    /// <summary>
    /// Do something when enemy dies.
    /// </summary>
    private void Die()
    {
        PlayerStats.Money += moneyGain;

        GameObject effect =  Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        Destroy(gameObject);
    }


}
