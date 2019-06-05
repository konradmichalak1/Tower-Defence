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

    static List<string> BulletNames = new List<string>()
    {
        "StandardBullet",
        "StandardBulletUpgraded",
        "Missile",
        "MissileUpgraded"
    };

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


    static public void SetAllBulletStats()
    {
        foreach (var BulletName in BulletNames)
        {
            if (!PlayerPrefs.HasKey(BulletName + "Damage"))
            {
                Debug.Log(BulletName + ": stats saved!");
                SetDefaultBulletDamage(BulletName);
                SetDefaultBulletSpeed(BulletName);
                SetDefaultBulleExplosionRadius(BulletName);
            }
        }

    }


    static public void SetDefaultBulletDamage(string BulletName)
    {
        //Example: LaserBeamerSlowPercentage
        string fullName = BulletName + Damage;

        switch (BulletName)
        {
            case "StandardBullet":
                {
                    PlayerPrefs.SetInt(fullName, 50);
                    break;
                }
            case "StandardBulletUpgraded":
                {
                    PlayerPrefs.SetInt(fullName, 60);
                    break;
                }
            case "Missile":
                {
                    PlayerPrefs.SetInt(fullName, 35);
                    break;
                }
            case "MissileUpgraded":
                {
                    PlayerPrefs.SetInt(fullName, 40);
                    break;
                }
        }
    }

    static public void SetDefaultBulletSpeed(string BulletName)
    {
        //Example: LaserBeamerSlowPercentage
        string fullName = BulletName + Speed;

        switch (BulletName)
        {
            case "StandardBullet":
                {
                    PlayerPrefs.SetFloat(fullName, 60);
                    break;
                }
            case "StandardBulletUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 65);
                    break;
                }
            case "Missile":
                {
                    PlayerPrefs.SetFloat(fullName, 30);
                    break;
                }
            case "MissileUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 40);
                    break;
                }
        }
    }

    static public void SetDefaultBulleExplosionRadius(string BulletName)
    {
        //Example: LaserBeamerSlowPercentage
        string fullName = BulletName + ExplosionRadius;

        switch (BulletName)
        {
            case "Missile":
                {
                    PlayerPrefs.SetFloat(fullName, 5);
                    break;
                }
            case "MissileUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 8);
                    break;
                }
        }
    }



}
