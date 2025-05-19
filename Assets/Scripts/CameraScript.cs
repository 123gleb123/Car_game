using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float maxZoom = 300f;
    public float minZoom = 150f;
    public float followSpeed = 5f;
    Vector3 bottomLeft, topRight;
    float cameraMaxX, cameraMaxY, cameraMinX, cameraMinY, x, y;
    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        topRight = cam.ScreenToWorldPoint(new Vector3(
            cam.pixelWidth, cam.pixelHeight, -transform.position.z));

        bottomLeft = cam.ScreenToWorldPoint(new Vector3(
            0, 0, -transform.position.z));

        cameraMaxX = topRight.x;
        cameraMaxY = topRight.y;
        cameraMinX = bottomLeft.x;
        cameraMinY = bottomLeft.y;

        Debug.Log("topRight x: " + topRight.x);
        Debug.Log("bottomLeft x: " + bottomLeft.x);
        Debug.Log("topRight y: " + topRight.y);
        Debug.Log("bottomLeft y: " + bottomLeft.y);
        Debug.Log("orthographicSize: " + cam.orthographicSize);
    }

    
    void Update()
    {
        x = Input.GetAxis("Mouse X") * followSpeed;
        y = Input.GetAxis("Mouse Y") * followSpeed;
        transform.Translate(x, y, 0);

        if(Input.GetAxis("Mouse ScrollWheel") > 0 && 
            cam.orthographicSize > minZoom)
        {
           cam.orthographicSize = cam.orthographicSize - 50f; 
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 &&
            cam.orthographicSize < maxZoom)
        {
            cam.orthographicSize = cam.orthographicSize + 50f;
        }
    }
}
