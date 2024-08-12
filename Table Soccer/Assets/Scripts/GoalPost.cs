using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    private int goal = 0;
    public TextMeshProUGUI Goal;
    [SerializeField] private Vector3 resetPosition = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private bool ballEntered = false;

    private void OnTriggerExit(Collider other)
    {
        // The entire ball has crossed the goal line.

        // Reset the ball's position
        other.transform.position = resetPosition;

        // Stop the ball's movement by setting its velocity to zero
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        other.GetComponent<Rigidbody>().Sleep();

        // Mark that the ball has entered to prevent multiple triggers.
        ballEntered = true;

        // Update Goal
        goal++;
        Goal.text = goal.ToString();
    }
}
