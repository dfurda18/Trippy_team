using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /**
     * The player's movement speed
     */
    public float maxSpeed = 30;
    /**
     * The acceleration force
     */
    public float acceleration = 12;
    /**
     * The player's side speed
     */
    public float sideSpeed = 4;
    /**
     * The jump Force
     */
    public float jumpSpeed = 14;
    /**
     * Whether or not the player is Jumping
     */
    public bool isGrounded = false;
    /**
     * Whther or not the player has stopped for some reason
     */
    public bool stopped = false;

    // Update is called once per frame
    void Update()
    {
        if(!this.stopped && this.GetComponent<Rigidbody>().velocity.magnitude < this.maxSpeed)
        {
            this.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * this.acceleration);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.Jump();
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.StopPlayer();
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.ContinueRunning();
        }
    }

    /**
     * Turns the player towards a specified direction
     * @param Direction direction The direction the player will turn to.
     */
    public void Turn(Direction direction)
    {
        Vector3 newDirection;
        switch(direction)
        {
            case Direction.North:
                newDirection = new Vector3(0, 0, 1);
                break;
            case Direction.South:
                newDirection = new Vector3(0, 0, -1);
                break;
            case Direction.East:
                newDirection = new Vector3(1, 0, 0);
                break;
            case Direction.West:
                newDirection = new Vector3(-1, 0, 0);
                break;
            default:
                newDirection = this.transform.forward;
                break;
        }
        this.gameObject.transform.LookAt(this.transform.position + newDirection);
        this.gameObject.transform.forward = newDirection;
    }

    /**
     * Makes the player jump
     */
    public void Jump()
    {
        if (this.isGrounded)
        {
            this.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.up * this.jumpSpeed);
        }
    }

    public void StopPlayer()
    {
        this.stopped = true;
    }

    public void ContinueRunning()
    {
        this.stopped = false;
    }
}
