using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavController : MonoBehaviour
{
    /**
     * this Instance
     */
    private static NavController instance;
    /**
     * The player
     */
    public GameObject player;
    /**
     * The player script
     */
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        NavController.instance = this;
        this.playerMove = this.player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Turns the player to a direction
     */
    public static void TurnPlayerToDirection(Direction direction)
    {
        NavController.instance.playerMove.Turn(direction);
    }

    public static GameObject GetPlayer()
    {
        return NavController.instance.player;
    }
}
