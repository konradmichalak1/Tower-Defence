using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
   public float perspectiveZoomSpeed = .15f;
   public float orthoZoomSpeed = .15f;
    private float minZoom = 10f;
    private float maxZoom = 37f;

    public Camera camera;

    void Start(){
        camera = GetComponent<Camera>( );
    }
    // Update is called once per frame
    void Update()
    {
        camera.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * perspectiveZoomSpeed * Time.deltaTime * -5000;
        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, minZoom, maxZoom);

        if (Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

            if(camera.orthographic){
                camera.orthographicSize += deltaMagnitudediff * orthoZoomSpeed;
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, .1f);
            }
            else {
                camera.fieldOfView += deltaMagnitudediff * perspectiveZoomSpeed;
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, minZoom, maxZoom * 100);
               // camera.fieldOfView = Mathf.Clamp(camera.fieldOfView * Time.deltaTime, minZoom, maxZoom * 100);
                //camera.fieldOfView = Mathf.Clamp(camera.fieldPfView, .1f, 179.9f);
            }
        }
      
        
    }
}
