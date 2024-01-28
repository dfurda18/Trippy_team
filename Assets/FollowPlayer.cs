using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Animator dogAnimator;
    public Transform Dog;
    public float currentDistanceFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Follow(Vector3 pos, float playerSpeed)
    {
        Vector3 position = pos - Vector3.forward * currentDistanceFromPlayer;
        Dog.position = Vector3.Lerp(Dog.position, position, Time.deltaTime * playerSpeed / currentDistanceFromPlayer);
    }
}
