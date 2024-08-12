using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class TSAgent : Agent
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject Rod1;
    [SerializeField] private GameObject Rod2;
    [SerializeField] private GameObject Rod3;
    [SerializeField] private GameObject Rod4;
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Ball.transform.position);
        sensor.AddObservation(Ball.transform.rotation);
        sensor.AddObservation(Rod1.transform.position.z);
        sensor.AddObservation(Rod1.transform.rotation.z);
        sensor.AddObservation(Rod2.transform.position.z);
        sensor.AddObservation(Rod2.transform.rotation.z);
        sensor.AddObservation(Rod3.transform.position.z);
        sensor.AddObservation(Rod3.transform.rotation.z);
        sensor.AddObservation(Rod4.transform.position.z);
        sensor.AddObservation(Rod4.transform.rotation.z);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float rod1InputX = actions.ContinuousActions[0];
        float rod1InputY = actions.ContinuousActions[1];
        float rod2InputX = actions.ContinuousActions[2];
        float rod2InputY = actions.ContinuousActions[3];
        float rod3InputX = actions.ContinuousActions[4];
        float rod3InputY = actions.ContinuousActions[5];
        float rod4InputX = actions.ContinuousActions[6];
        float rod4InputY = actions.ContinuousActions[7];

        Movement rod1Movement = Rod1.GetComponent<Movement>();
        rod1Movement.inputX = rod1InputX;
        rod1Movement.inputY = rod1InputY;

        Movement rod2Movement = Rod2.GetComponent<Movement>();
        rod2Movement.inputX = rod2InputX;
        rod2Movement.inputY = rod2InputY;

        Movement rod3Movement = Rod3.GetComponent<Movement>();
        rod3Movement.inputX = rod3InputX;
        rod3Movement.inputY = rod3InputY;

        Movement rod4Movement = Rod4.GetComponent<Movement>();
        rod4Movement.inputX = rod4InputX;
        rod4Movement.inputY = rod4InputY;


        float deviation = Mathf.Abs(Rod1.transform.eulerAngles.z);
        float reward = Mathf.Clamp01(1f - 0.1f * deviation);
        float penalty = -0.01f * deviation;
        float totalReward = reward + penalty;
        SetReward(totalReward);

    }
}
