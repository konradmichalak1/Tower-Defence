using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
    public float minY = 10f;
    public float maxY = 80f;
    public float scrollSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(0);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(0);
            cam.transform.position += direction;
        }

        //Zooming
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference);

        }

        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }
    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, new Vector3(0, 0, 0));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }

    void zoom(float increment)
    {
        Vector3 pos = transform.position;
        pos.y -= increment * scrollSpeed * Time.deltaTime * 1000;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        cam.transform.position = pos;

    }
}