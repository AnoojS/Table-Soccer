using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveSpeed = 0.1f;
    private float rotateSpeed = 100f;
    [SerializeField] private float minPosition = 0f;
    [SerializeField] private float maxPosition = 0f;
    private float minRotation = -90f;
    private float maxRotation = 90f;
    public float inputX = 0f;
    public float inputY = 0f;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        Vector3 moveDir = new Vector3(0f, 0f, inputY);
        moveDir *= moveSpeed * Time.deltaTime;

        Vector3 currentPosition = transform.position;
        currentPosition.z += moveDir.z;
        currentPosition.z = Mathf.Clamp(currentPosition.z, minPosition, maxPosition);

        transform.position = currentPosition;


        Vector3 rotateDir = new Vector3(0f, 0f, inputX);
        rotateDir *= rotateSpeed * Time.deltaTime;

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z += rotateDir.z;
        currentRotation.z = (currentRotation.z + 180) % 360 - 180;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);

        transform.eulerAngles = currentRotation;
    }
}