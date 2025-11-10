using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] float sensitivity = 2f;
    float cameraVerticalRotation = 0f;
    public Transform playerTransform;

    void Update()
    {
        if (!playerTransform) return;

        float inputX = Input.GetAxis("Mouse X") * sensitivity;
        float inputY = Input.GetAxis("Mouse Y") * sensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        playerTransform.Rotate(Vector3.up * inputX);
    }
}