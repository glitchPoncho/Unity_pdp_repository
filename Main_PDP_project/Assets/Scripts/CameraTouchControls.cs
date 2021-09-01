using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTouchControls : MonoBehaviour
{
    private Vector3 touchStart;

   [SerializeField]
    float limitLeft;
    [SerializeField]
    float limitRight;
    [SerializeField]
    float limitUp;
    [SerializeField]
    float limitBottom;
   

    [SerializeField]
    float minCamSize = 1;
    [SerializeField]
    float maxCamSize = 6;

    public SpriteRenderer rink;
    
    void Start()
    {
        float screenRation = (float)Screen.width / (float)Screen.height;
        float targetRation = rink.bounds.size.x / rink.bounds.size.y;


      
    }

    // Update is called once per frame
    void Update()
    {
        /*
         float cameraStops = Camera.main.transform.position.x;
        if (cameraStops < -5 )
            Camera.main.transform.position =new Vector3 ( -5f,Camera.main.transform.position.y, Camera.main.transform.position.z);
        if (cameraStops > 5)
            Camera.main.transform.position = new Vector3(5f, Camera.main.transform.position.y, Camera.main.transform.position.z);/
        */

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 PrePosZero = touchZero.position - touchZero.deltaPosition;
            Vector2 PrePosOne = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (PrePosZero - PrePosOne).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }


        if (Input.GetMouseButtonDown(0))
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, limitLeft, limitRight),
            Mathf.Clamp(transform.position.y, limitBottom, limitUp),
            transform.position.z
            );

    }



    void Zoom (float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, minCamSize, maxCamSize);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(limitLeft, limitUp), new Vector2(limitRight, limitUp));
        Gizmos.DrawLine(new Vector2(limitRight, limitUp), new Vector2(limitRight, limitBottom));
        Gizmos.DrawLine(new Vector2(limitRight, limitBottom), new Vector2(limitLeft, limitBottom));
        Gizmos.DrawLine(new Vector2(limitLeft, limitBottom), new Vector2(limitLeft, limitUp));
    }
}
