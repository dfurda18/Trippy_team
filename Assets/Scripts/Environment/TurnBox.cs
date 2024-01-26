using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBox : MonoBehaviour
{
    /**
     * if this box makes you turn left or not
     */
    public bool turnLeft = true;
    // Called when the player has entered this box
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NavController.TurnPlayerToDirection(turnLeft ? 
                this.gameObject.GetComponentInParent<EnvironmentSection>().GetLeft() : 
                this.gameObject.GetComponentInParent<EnvironmentSection>().GetRight());
        }
    }
}
