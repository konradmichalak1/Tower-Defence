using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gets or sets all turrets global stats
/// </summary>
public class TurretsStats : MonoBehaviour
{

    const string Range = "Range";
    const string FireRate = "FireRate";
    const string DamageOverTime = "DamageOverTime";
    const string SlowPercentage = "SlowPercentage";

    /// <summary>
    /// Stores all turrets names
    /// </summary>
    static List<string> TurretsNames = new List<string>()
    {
        "StandardTurret",
        "StandardTurretUpgraded",
        "MissileLauncher",
        "MissileLauncherUpgraded",
        "LaserBeamer",
        "LaserBeamerUpgraded"
    };

    /* List of turretNames:
     * StandardTurret
     * StandardTurretUpgraded
     * MissileLauncher
     * MissileLauncherUpgraded
     * LaserBeamer
     * LaserBeamerUpgraded 
    */
    #region Get

    /// <summary>
    /// Returns turret range.
    /// </summary>
    static public float GetTurretRange(string TurretName)
    {
        //Example: StandardTurretUpgradedRange
        string fullName = TurretName + Range;

        switch (TurretName)
        {
            case "StandardTurret":
                {
                    return PlayerPrefs.GetFloat(fullName, 15f);
                }
            case "StandardTurretUpgraded":
                {
                    return PlayerPrefs.GetFloat(fullName, 20f);
                }
            case "MissileLauncher":
                {
                    return PlayerPrefs.GetFloat(fullName, 25f);
                }
            case "MissileLauncherUpgraded":
                {
                    return PlayerPrefs.GetFloat(fullName, 30f);
                }
            case "LaserBeamer":
                {
                    return PlayerPrefs.GetFloat(fullName, 20f);
                }
            case "LaserBeamerUpgraded":
                {
                    return PlayerPrefs.GetFloat(fullName, 25f);
                }
        }

        return 0f;
    }

    static public float GetTurretFireRate(string TurretName)
    {
        //Example: MissileLauncherFireRate
        string fullName = TurretName + FireRate;

        switch (TurretName)
        {
            case "StandardTurret":
                {
                    return PlayerPrefs.GetFloat(fullName, 1f);
                }
            case "StandardTurretUpgraded":
                {
                    return PlayerPrefs.GetFloat(fullName, 1.5f);
                }
            case "MissileLauncher":
                {
                    return PlayerPrefs.GetFloat(fullName, 0.5f);
                }
            case "MissileLauncherUpgraded":
                {
                    return PlayerPrefs.GetFloat(fullName, 0.7f);
                }
        }

        return 0f;
    }

    static public int GetTurretDamageOverTime(string TurretName)
    {   //Example: LaserBeamerDamageOverTime
        string fullName = TurretName + DamageOverTime;

        switch (TurretName)
        {

            case "LaserBeamer":
                {
                    return PlayerPrefs.GetInt(fullName, 30);
                }
            case "LaserBeamerUpgraded":
                {
                    return PlayerPrefs.GetInt(fullName, 40);
                }
        }

        return 0;
    }

    static public float GetTurretSlowPercentage(string TurretName)
    {
        //Example: LaserBeamerSlowPercentage
        string fullName = TurretName + SlowPercentage;

        switch (TurretName)
        {
            case "LaserBeamer":
                {
                    return PlayerPrefs.GetFloat(fullName, 0.4f);
                }
            case "LaserBeamerUpgraded":
                {
                    return PlayerPrefs.GetFloat(fullName, 0.55f);
                }
        }
        return 0f;
    }

    #endregion

    #region Set

    static public void SetAllTurretStats()
    {
        foreach (var TurretName in TurretsNames)
        {
            if (!PlayerPrefs.HasKey(TurretName + "Range"))
            {
                Debug.Log(TurretName + ": stats saved!");
                SetDefaultTurretRange(TurretName);
                SetDefaultTurretFireRate(TurretName);
                SetDefaultTurretDamageOverTime(TurretName);
                SetDefaultTurretSlowPercentage(TurretName);
            }
        }

    }
    /// <summary>
    /// Sets turret range.
    /// </summary>
    static public void SetDefaultTurretRange(string TurretName)
    {
        //Example: StandardTurretUpgradedRange
        string fullName = TurretName + Range;

        switch (TurretName)
        {
            case "StandardTurret":
                {
                    PlayerPrefs.SetFloat(fullName, 15f);
                    break;
                }
            case "StandardTurretUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 20f);
                    break;
                }
            case "MissileLauncher":
                {
                    PlayerPrefs.SetFloat(fullName, 25f);
                    break;
                }
            case "MissileLauncherUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 30f);
                    break;
                }
            case "LaserBeamer":
                {
                    PlayerPrefs.SetFloat(fullName, 20f);
                    break;
                }
            case "LaserBeamerUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 25f);
                    break;
                }
        }

    }

    static public void SetDefaultTurretFireRate(string TurretName)
    {
        //Example: MissileLauncherFireRate
        string fullName = TurretName + FireRate;

        switch (TurretName)
        {
            case "StandardTurret":
                {
                    PlayerPrefs.SetFloat(fullName, 1f);
                    break;
                }
            case "StandardTurretUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 1.5f);
                    break;
                }
            case "MissileLauncher":
                {
                    PlayerPrefs.SetFloat(fullName, 0.5f);
                    break;
                }
            case "MissileLauncherUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 0.7f);
                    break;
                }
        }
    }

    static public void SetDefaultTurretDamageOverTime(string TurretName)
    {   //Example: LaserBeamerDamageOverTime
        string fullName = TurretName + DamageOverTime;

        switch (TurretName)
        {
            case "LaserBeamer":
                {
                    PlayerPrefs.SetInt(fullName, 30);
                    break;
                }
            case "LaserBeamerUpgraded":
                {
                    PlayerPrefs.SetInt(fullName, 40);
                    break;
                }
        }

    }

    static public void SetDefaultTurretSlowPercentage(string TurretName)
    {
        //Example: LaserBeamerSlowPercentage
        string fullName = TurretName + SlowPercentage;

        switch (TurretName)
        {
            case "LaserBeamer":
                {
                    PlayerPrefs.SetFloat(fullName, 0.4f);
                    break;
                }
            case "LaserBeamerUpgraded":
                {
                    PlayerPrefs.SetFloat(fullName, 0.55f);
                    break;
                }
        }
    }
    #endregion
}
