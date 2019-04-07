using UnityEngine;

public class NodeUI : MonoBehaviour {

    private NodeController target;
    public GameObject ui;
    public void SetTarget(NodeController _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
