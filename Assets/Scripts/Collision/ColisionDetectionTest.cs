using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColisionDetectionTest : MonoBehaviour
{
    [SerializeField] private string colisionTag = "Player";
    
    /* 
     * Animation Trigger Variables
     */
    [SerializeField] private UnityEvent FastRunAnimationTrigger;

    //Access the playermove script to stop the default movement speed 
    
    
    

    //save the speed 
    private float jr_pm_Default_Speed;

    //stop the players movements 
    private float jr_Fall_Stop_Speed = 0f;



    // Start is called before the first frame update
    void Start()
    {
        //jr_PlayerMove = jr_navCon_instance.player.GetComponent<PlayerMove>();
        jr_PlayerMove = jr_navCon_instance.playerMove;
        //jr_pm_Default_Speed = jr_PlayerMove.speed;
        //Debug.Log(jr_PlayerMove.speed.ToString());


        jr_pm_Default_Speed =NavController.GetPlayer().GetComponent<PlayerMove>().speed;
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
                //jr_PlayerMove.speed = jr_Fall_Stop_Speed; // set the PlayerMove script speed to zero
                PlayerMove.speed = jr_Fall_Stop_Speed; // set the PlayerMove script speed to zero


                //jr_pm_instance.speed = jr_Fall_Stop_Speed; // set the PlayerMove script speed to zero
                Debug.Log("PlayerMove: Speed Variable == " + PlayerMove.speed.ToString());

                // Run the Stumble Animation 
                FastRunAnimationTrigger.Invoke();//trigger the trigger in the animation 
                Debug.Log("Colision fall triggered");

                // delay the reset of the speed variable 
                Invoke("ResetPlayerMoveSpeedToDefault", 2.0f);

            }//end if else 
        }//end outer if 

    }//end on collision enter

    private void ResetPlayerMoveSpeedToDefault()
    {
        // after animation is done start moving again with the saved default speed 
        PlayerMove.speed = jr_pm_Default_Speed;
        //jr_pm_instance.speed = jr_pm_Default_Speed;
    }// end player speed reset method 
}
