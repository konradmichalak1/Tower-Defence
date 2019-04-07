using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameMaster object script
/// </summary>
public class BuildManager : MonoBehaviour {

    #region Singleton pattern definition - only one instance of BuildManager is accessable
    public static BuildManager instance;

    /// <summary>
    /// It's called right before start
    /// </summary>
    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    /// <summary>
    /// Turret that is selected in shop.
    /// </summary>
    private TurretBlueprint turretToBuild;

    /// <summary>
    /// Node that is selected on map.
    /// </summary>
    private NodeController selectedNode;

    /// <summary>
    /// 
    /// </summary>
    public NodeUI nodeUI;

    /// <summary>
    /// Build effect prefab - particle system effect.
    /// </summary>
    public GameObject buildEffect;

    /// <summary>
    /// Returns true if player has selected any turret to build.
    /// </summary>
    public bool CanBuild
    {
        get {
            return turretToBuild != null;
        }
    }
    
    /// <summary>
    /// Returns true if player has enough money to build turret.
    /// </summary>
    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    /// <summary>
    /// If player has enough money, intantiates selected Turret into indicated Node.
    /// </summary>
    /// <param name="node">Node on which the turret will be built.</param>
    public void BuildTurretOn(NodeController node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        //Build a turret that is selected in Shop
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        //Creates building effect and destroy it from Scene after 2s
        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
    }

    public void SelectNode(NodeController node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    /// <summary>
    /// Selects turret that has been chosen by player in shop.
    /// </summary>
    /// <param name="turret"></param>
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
}
