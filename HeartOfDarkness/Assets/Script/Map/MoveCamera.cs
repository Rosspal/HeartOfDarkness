using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private int screenWidth;
    private int screenHeight;
    public float speed;
    public bool useCameraMovement = true;
    public float x1, x2, y1, y2;
    public float tempX1, tempX2, tempY1, tempY2;
    public float test;
    public float zoomSpeed;
    public float percentX, percentY;

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        tempX1 = x1; tempX2 = x2; tempY1 = y1; tempY2 = y2;
    }

    void Update()
    {
        if (useCameraMovement)
        {
            Vector3 camPos = transform.position;

            if (Input.mousePosition.x <= test)
            {
                camPos.x -= Time.deltaTime * speed;
                //camPos.y += Time.deltaTime * speed;
            }
            if (Input.mousePosition.x >= screenWidth - test)
            {
                camPos.x += Time.deltaTime * speed;
                //camPos.y -= Time.deltaTime * speed;
            }
            if (Input.mousePosition.y <= test)
            {
                //camPos.x -= Time.deltaTime * speed;
                camPos.y -= Time.deltaTime * speed;
            }
            if (Input.mousePosition.y >= screenHeight - test)
            {
                //camPos.x += Time.deltaTime * speed;
                camPos.y += Time.deltaTime * speed;
            }

            transform.position = new Vector3(Mathf.Clamp(camPos.x, tempX1, tempX2), Mathf.Clamp(camPos.y, tempY1, tempY2), camPos.z);
            //transform.position = camPos;

            float zoom = Input.GetAxis("Mouse ScrollWheel");

            if (zoom < 0)
            {
                if (Camera.main.orthographicSize <= (1 - zoomSpeed))
                {
                    Camera.main.orthographicSize += zoomSpeed;
                    tempX1 += percentX;
                    tempX2 -= percentX;
                    tempY1 += percentY;
                    tempY2 -= percentY;
                }
                else
                {
                    Camera.main.orthographicSize = 1;
                }
            }

            if (zoom > 0)
            {
                if (Camera.main.orthographicSize >= (0.5 + zoomSpeed))
                {
                    Camera.main.orthographicSize -= zoomSpeed;
                    tempX1 += percentX;
                    tempX2 -= percentX;

                    tempY1 -= percentY;
                    tempY2 += percentY;
                }
                else
                {
                    Camera.main.orthographicSize = (float)0.5;
                    tempX1 = x1;
                    tempX2 = x2;
                    tempY1 = y1;
                    tempY2 = y2;
                }
            }
        }
    }
}
