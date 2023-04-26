using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {
    public float mouseSensitivity = 30.0f;

    public float clampAngle = 20.0f;

    private float yAxisRot = 0.0f;      // rotation around the up/y axis
    private float xAxisRot = 0.0f;      // rotation around the right/x axis

    private float turnSpeed = 5.0f;

    public Transform target;

    public float targetDistance = 2.5f;

    void Start () {
        Vector3 rot = transform.localRotation.eulerAngles;
        yAxisRot = rot.y;
        xAxisRot = rot.x;
        Cursor.visible = false;
    }

    void Update () {
        float mouseAxisX = Input.GetAxis(axisName: "Mouse X") * turnSpeed;
        float mouseAxisY = -Input.GetAxis(axisName: "Mouse Y") * turnSpeed;

        yAxisRot += mouseAxisX * mouseSensitivity * Time.fixedDeltaTime;
        xAxisRot += mouseAxisY * mouseSensitivity * Time.fixedDeltaTime;

        xAxisRot = Mathf.Clamp(value: xAxisRot, min: -clampAngle, max: clampAngle * 3);

        Vector3 newPos =target.transform.position - (transform.forward * targetDistance);
        newPos.y += 0.18f;
        newPos.y = transform.position.y;
        transform.position = newPos;
        
        Quaternion localRotation = Quaternion.Euler(x: 0, y: yAxisRot, z: 0.0f);
        transform.rotation = localRotation;
    }
}