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
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundry.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundry.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1);
            }
        }
    }
}
