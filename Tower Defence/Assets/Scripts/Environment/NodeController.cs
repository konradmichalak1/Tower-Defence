using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Node.prefab script
/// </summary>
public class NodeController : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;

    /// <summary>
    /// Offset of turret position during spawn
    /// </summary>
    public Vector3 positionOffset;
    /// <summary>
    /// Turret that is currently builded on this node
    /// </summary>
    [Header("Optional")]
    public GameObject turret;

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

        buildManager.BuildTurretOn(this);
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
