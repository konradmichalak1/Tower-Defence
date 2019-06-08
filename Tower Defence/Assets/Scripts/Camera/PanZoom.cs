using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour {
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
	public Camera camera;
    
    void Start(){
        camera = GetComponent<Camera>( );
    }
    
	// Update is called once per frame
	void Update () {

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }


        if (Input.GetMouseButtonDown(0)){
            touchStart = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.1f);
        }else if(Input.GetMouseButton(0)){
            Vector3 direction = touchStart - camera.ScreenToWorldPoint(Input.mousePosition);
            camera.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
	}

    void zoom(float increment){
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}