using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class RodAgent : Agent
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject Rod1;
    [SerializeField] private GameObject Rod2;
    [SerializeField] private GameObject Rod3;
    [SerializeField] private GameObject Rod4;
    [SerializeField] private GameObject Rod5;
    [SerializeField] private GameObject Rod6;
    [SerializeField] private GameObject Rod7;

    public override void CollectObservations(VectorSensor sensor)
    {
        //sensor.AddObservation(Ball.transform.position);
        //sensor.AddObservation(Ball.transform.rotation);
        //sensor.AddObservation(transform.position.z);
        sensor.AddObservation(transform.rotation.z);
        //sensor.AddObservation(Rod1.transform.position.z);
        //sensor.AddObservation(Rod1.transform.rotation.z);
        //sensor.AddObservation(Rod2.transform.position.z);
        //sensor.AddObservation(Rod2.transform.rotation.z);
        //sensor.AddObservation(Rod3.transform.position.z);
        //sensor.AddObservation(Rod3.transform.rotation.z);
        //sensor.AddObservation(Rod4.transform.position.z);
        //sensor.AddObservation(Rod4.transform.rotation.z);
        //sensor.AddObservation(Rod5.transform.position.z);
        //sensor.AddObservation(Rod5.transform.rotation.z);
        //sensor.AddObservation(Rod6.transform.position.z);
        //sensor.AddObservation(Rod6.transform.rotation.z);
        //sensor.AddObservation(Rod7.transform.position.z);
        //sensor.AddObservation(Rod7.transform.rotation.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float rodInputX = actions.ContinuousActions[0];
        float rodInputY = actions.ContinuousActions[1];

        Movement rodMovement = GetComponent<Movement>();
        rodMovement.inputX = rodInputX;
        rodMovement.inputY = rodInputY;


        float targetAngle = 0.0f;
        float currentAngle = Mathf.Abs(transform.eulerAngles.z);

        float deviation = targetAngle - currentAngle;

        SetReward(deviation);
    }
}