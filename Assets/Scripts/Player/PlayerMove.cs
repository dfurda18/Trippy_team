using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /**
     * The player's movement speed
     */
    public float speed = 3;
    /**
     * The player's side speed
     */
    public float sideSpeed = 4;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.gameObject.transform.forward * Time.deltaTime * speed, Space.World);
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1);
        }
    }

    public void Turn(Direction direction)
    {
        Vector3 newDirection;
        float angle = 0f;
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
}
