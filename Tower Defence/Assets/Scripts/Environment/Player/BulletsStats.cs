using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsStats : MonoBehaviour {

    public int damage = 50;
    public float speed = 70f;
    public float explosionRadius = 0f;

    /* List of bullets names:
     * StandardBullet
     * StandardBulletUpgraded
     * Missile
     * MissileUpgraded
    */

    static public int GetBulletDamage(string BulletName)
    {
        return 0;
    }

    static public float GetBulletSpeed(string BulletName)
    {
        return 0f;
    }
    static public float GetBulletRadius(string BulletName)
    {
        return 0f;
    }



}
