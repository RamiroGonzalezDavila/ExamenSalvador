using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKnife : MonoBehaviour
{
    public GameObject knife;
    public float movementSpeed = 2f;
    public float rotationSpeed = 400f; 
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the knife's position and rotation
        knife.transform.position = new Vector3(40f, 1.5f, 30f); // Adjust initial position
        knife.transform.rotation = Quaternion.Euler(0f, 90f, 0f); // Adjust initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        MoveKnife();
    }

    void MoveKnife()
    {
        // Calculate the target position based on the current direction
        float targetX = movingRight ? 40f : 30f; // Adjust target position

        // Move the knife towards the target position
        knife.transform.position = Vector3.MoveTowards(knife.transform.position, new Vector3(targetX, 1.5f, 30f), movementSpeed * Time.deltaTime);

        // Rotate the knife based on the direction
        float rotationAngle = movingRight ? 90f : -90f; // Adjust rotation angle
        knife.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);

        // Check if the knife has reached the target position and change direction
        if (knife.transform.position.x == targetX)
        {
            movingRight = !movingRight;
        }
    }
}