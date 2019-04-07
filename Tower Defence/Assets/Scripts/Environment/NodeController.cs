using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Node.prefab script
/// </summary>
public class NodeController : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;

    /// <summary>
    /// Offset of turret position during spawn.
    /// </summary>
    public Vector3 positionOffset;
    /// <summary>
    /// Turret that is currently builded on this node.
    /// </summary>
    [HideInInspector]
    public GameObject turret;
    /// <summary>
    /// Selected turret blueprint.
    /// </summary>
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    /// <summary>
    /// Is builded turret currently upgraded?
    /// </summary>
    [HideInInspector]
    public bool isUpgraded = false;

    /// <summary>
    /// This object renderer (In unity this is component called "Mesh Renderer")
    /// </summary>
    private Renderer rend;
    /// <summary>
    /// Oryginal object color
    /// </summary>
    private Color startColor;

    BuildManager buildManager; 

    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    /// <summary>
    /// Return node position
    /// </summary>
    /// <returns></returns>
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    /// <summary>
    /// Whenever mouse clicked on this object, insert turret.
    /// </summary>
    private void OnMouseDown()
    {
        //If node is over Shop item (for example when you select item to buy when that item is over node - it causes that both are clicked)
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //If turret is already build on this node, select this node (upgrading/selling turrets)
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        //If there is no turret selected in shop, return 
        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }
    /// <summary>
    /// If player has enough money, intantiates indicated Turret into Node.
    /// </summary>
    /// <param name="blueprint">Which the turret will be built.</param>
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        //Build a turret that is selected in Shop
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        //Creates building effect and destroy it from Scene after 2s
        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
    }

    /// <summary>
    /// If player has enough money, upgrade turret that is actually builded on this node.
    /// </summary>
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Build a upgraded turret
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        //Creates building effect and destroy it from Scene after 2s
        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        isUpgraded = true;
    }
    /// <summary>
    /// Selling buildt turret
    /// </summary>
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //Creates selling effect and destroy it from Scene after 2s
        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;

    }

    /// <summary>
    /// When mouse is on this object change color of this object
    /// </summary>
    private void OnMouseEnter()
    {
        //If node is over Shop item (for example when you select item to buy when that item is over node - it causes that both are clicked)
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //If there is no turret selected in shop, return (it prevents from changing node color when there is no turret selected)
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {

            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    /// <summary>
    /// When mouse is out of this object change color to its oryginal color
    /// </summary>
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
