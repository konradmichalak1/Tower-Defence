using UnityEngine;
/// <summary>
/// Main Camera object script
/// </summary>
public class CameraController : MonoBehaviour {

    /// <summary>
    /// Camera speed
    /// </summary>
    public float panSpeed = 30f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    /// <summary>
    /// Offset that enables to change camera with mouse
    /// </summary>
    public float panBorderThickness = 10f;
	void Update () {

        //If game is over, camera stops working.
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        //Zooming
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
