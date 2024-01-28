using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Events;

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
    public bool isGrounded = true;
    /**
     * Whther or not the player has stopped for some reason
     */
    public bool gameStart = false;

    /**
    * The script on the dog thats chasing the player
    */
    public FollowPlayer dog;
    private float currentDistance = 0.6f; // this is the minimum follow distance 

    // Update is called once per frame
    void Update()
    {
        

        if (this.GetComponentInChildren<Animator>().GetBool("isRunning") && this.GetComponent<Rigidbody>().velocity.magnitude < this.maxSpeed)
        {
            this.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * this.acceleration);


            //After collision the dog gets closer 
            //if (our distance meeter count is less than 5 move dog closer to the player else stays away
            //currentDistance = Mathf.MoveTowards(currentDistance, 5f, Time.deltaTime * 0.01f);
            
            //add the dogs movement
            dog.Follow(this.gameObject.transform.forward, this.transform.position, this.acceleration);
        }
        /**
         * Add an else where the dog catches up to the player??
         */
        
        if (this.GetComponentInChildren<Animator>().GetBool("isRunning") && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
        }

        if (this.GetComponentInChildren<Animator>().GetBool("isRunning") && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.RightArrow))
        {
            this.gameStart = true;
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
        if (this.GetComponentInChildren<Animator>().GetBool("isRunning") && this.isGrounded)
        {
            this.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.up * this.jumpSpeed);
            this.GetComponentInChildren<Animator>().SetTrigger("isJumping");
            this.isGrounded = false;
        }
    }

    /**
     * Manual Stop Player
     */
    public void StopPlayer()
    {
        this.GetComponentInChildren<Animator>().SetBool("isRunning", false);
    }

    /**
     * Manual Start Player movement
     */
    public void ContinueRunning()
    {
        this.GetComponentInChildren<Animator>().SetBool("isRunning", true);
    }

    /**
     * Detect player's collissions
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            this.isGrounded = true;
        }
    }

     /**
     * Make the player invincible!!!
     * by getting its colliders and siabling them for 3 seconds
     */
    public void EnableInvincibility()
    {
        //this.GetComponent<BoxCollider>().excludeLayers("");
        //this.GetComponent<BoxCollider>().excludeLayers;
        //this.GetComponent<SphereCollider>().enabled = false;
    }

    public void DisableInvincibility()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        //this.GetComponent<SphereCollider>().enabled = false;
    }

}
