using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Animator dogAnimator;
    public Transform Dog;
    public float currentDistanceFromPlayer;

   

    public void StumbleBack()
    {
        //if (our distance meeter count is less than 5 move dog closer to the player else stays away

            //StopAllCoroutines();
            //dog goes in for the... 
            StartCoroutine(PlayAnim("Dog_RunFast"));
            
    }

    private IEnumerator PlayAnim(string anim)
    {
        yield return new WaitForSeconds(currentDistanceFromPlayer / 5f);
        dogAnimator.Play(anim);
    }

    // Update is called once per frame
    public void Follow(Vector3 forward, Vector3 pos, float playerSpeed)
    {
        Vector3 position = pos - forward * currentDistanceFromPlayer;
        this.gameObject.transform.LookAt(position + forward);
        Dog.position = Vector3.Lerp(Dog.position, position, Time.deltaTime * playerSpeed / currentDistanceFromPlayer);
    }
}
