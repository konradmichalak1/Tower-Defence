using UnityEngine;

/// <summary>
/// Shop panel script
/// </summary>
public class Shop : MonoBehaviour {

    //Each blueprint has to be initialized inside Unity editor - drag 'n drop Turret Object into Prefab field
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectLaserBeamerTurret()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
    public void SelectMissileLauncherTurret()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectStandardTurretTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
}
