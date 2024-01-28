using Audio;
using UnityEngine;
using UnityEngine.Events;

namespace Collision
{
    public class ColisionDetectionTest : MonoBehaviour
    {
        [SerializeField] private string colisionTag = "Player";
    
        /* 
     * Animation Trigger Variables
     */
        [SerializeField] private UnityEvent FastRunAnimationTrigger;

        //Access the playermove script to stop the default movement speed 
        private bool stopPlayer = false;

        //private BetterAudioManager _audioManager;

        // Start is called before the first frame update
        void Start()
        {
            //_audioManager = GameObject.Find("SFX_Jump_Generic").GetComponent<BetterAudioManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (collision.collider.CompareTag(colisionTag))
            {
                if (FastRunAnimationTrigger == null)
                {
                    print("ColisionDetectionTest was triggered but FastRunAnimationTrigger was NULL");
                } else 
                {
                    // first stop the movement speed of the player 
                    NavController.GetPlayer().StopPlayer();

                    // Run the Stumble Animation 
                    FastRunAnimationTrigger.Invoke();//trigger the trigger in the animation 
                    Debug.Log("Colision fall triggered");
                    BetterAudioManager.Instance.PlaySFX("Jump");

                }//end if else 
            }//end outer if 

        }//end on collision enter

        private void ResetPlayerMoveSpeedToDefault()
        {
            // after animation is done start moving again with the saved default speed 
            NavController.GetPlayer().ContinueRunning();
        }// end player speed reset method 
    }
}
