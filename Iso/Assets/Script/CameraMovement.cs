using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private int currentDirection = 0;
    private Vector3[] directions = new Vector3[]
    {
        new Vector3(30, 45, 0),   // Front-Right View
        new Vector3(30, 135, 0),  // Back-Right View
        new Vector3(30, 225, 0),  // Back-Left View
        new Vector3(30, 315, 0)   // Front-Left View
    };

    public float rotationSpeed = 1f; // Speed of rotation
    public float positionChangeSpeed = 1f; // Speed of position change
    private bool isRotating = false; // Is the camera currently rotating?
    public float zoomSpeed = 1f; // Speed of zoom
    public float minZoom; // Minimum zoom distance
    public float maxZoom; // Maximum zoom distance
    private Vector3 targetPosition;
    private float currentZoom;
    private void Start()
    {
        currentZoom = Camera.main.orthographicSize;
    }
    void Update()
    {
        if (!isRotating && Input.GetKeyDown(KeyCode.A))
        {
            currentDirection = (currentDirection + 1) % directions.Length;
            StartCoroutine(RotateCamera(directions[currentDirection]));
        }
        else if (!isRotating && Input.GetKeyDown(KeyCode.D))
        {
            currentDirection--;
            if (currentDirection < 0)
            {
                currentDirection += directions.Length;
            }
            StartCoroutine(RotateCamera(directions[currentDirection]));
        }
      
        CameraZoomInOut();
    }

    IEnumerator RotateCamera(Vector3 targetRotation)
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(targetRotation);

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
       
        isRotating = false;
    }


    void CameraZoomInOut()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        if (scrollData != 0)
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPosBeforeZoom = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            currentZoom -= scrollData * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            Camera.main.orthographicSize = currentZoom;

            Vector3 mouseWorldPosAfterZoom = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector3 adjustment = mouseWorldPosBeforeZoom - mouseWorldPosAfterZoom;

            Camera.main.transform.position += adjustment;
        }
    }
}
