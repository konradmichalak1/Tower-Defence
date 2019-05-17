using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsStats : MonoBehaviour {

    const string Damage = "Damage";
    const string Speed = "Speed";
    const string ExplosionRadius = "ExplosionRadius";
    /* List of bullets names:
     * StandardBullet
     * StandardBulletUpgraded
     * Missile
     * MissileUpgraded
    */

    static public int GetBulletDamage(string BulletName)
    {  
        //Example: StandardBulletUpgradedDamage
        string fullName = BulletName + Damage;

        switch (BulletName)
        {
            case "StandardBullet":
                {
                    return PlayerPrefs.GetInt(fullName, 50);
                }
            case "StandardBulletUpgraded":
                {
                    return PlayerPrefs.GetInt(fullName, 60);
                }
            case "Missile":
                {
                    return PlayerPrefs.GetInt(fullName, 35);
                }
            case "MissileUpgraded":
                {
                    return PlayerPrefs.GetInt(fullName, 40);
                }
        }

        return 0;
    }

    static public float GetBulletSpeed(string BulletName)
    {        
        //Example: MissileSpeed
        string fullName = BulletName + Speed;

        switch (BulletName)
        {
            case "StandardBullet":
            {
                return PlayerPrefs.GetFloat(fullName, 60);
            }
            case "StandardBulletUpgraded":
            {
                return PlayerPrefs.GetFloat(fullName, 65);
            }
            case "Missile":
            {
                return PlayerPrefs.GetFloat(fullName, 30);
            }
            case "MissileUpgraded":
            {
                return PlayerPrefs.GetFloat(fullName, 40);
            }
        }

        return 0f;
    }
    static public float GetBulletExplosionRadius(string BulletName)
    {
        //Example: MissileSpeed
        string fullName = BulletName + ExplosionRadius;

        switch (BulletName)
        {

            case "Missile":
            {
                return PlayerPrefs.GetFloat(fullName, 5);
            }
            case "MissileUpgraded":
            {
                return PlayerPrefs.GetFloat(fullName, 8);
            }
        }

        return 0f;
    }



}
