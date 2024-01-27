using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColisionDetectionTest : MonoBehaviour
{
    [SerializeField] private string colisionTag = "Player";
    Rigidbody rb;
    
    /* 
     * Animation Trigger Variables
     */
    [SerializeField] private UnityEvent FastRunAnimationTrigger;

    //Access the playermove script to stop the default movement speed 
    //public PlayerMove jr_pm_instance;
    //private static float jr_pm_Default_Speed;
    //private static float jr_Fall_Stop_Speed = 0f;



    // Start is called before the first frame update
    void Start()
    {
        //jr_pm_instance = GetComponent<PlayerMove>();
        //jr_pm_Default_Speed = jr_pm_instance.speed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == colisionTag)
        {
            if (FastRunAnimationTrigger == null)
            {
                print("ColisionDetectionTest was triggered but FastRunAnimationTrigger was NULL");
            } else 
            {
                // first stop the movement speed of the player 
                //jr_pm_instance.speed = jr_Fall_Stop_Speed; // set the PlayerMove script speed to zero


                // Run the Stumble Animation 
                FastRunAnimationTrigger.Invoke();//trigger the trigger in the animation 
                Debug.Log("Colision fall triggered");


                // after animation is done start moving again with the saved default speed 
                //jr_pm_instance.speed = jr_pm_Default_Speed;

            }//end if else 
        }//end outer if 
    }//end on collision enter
}
