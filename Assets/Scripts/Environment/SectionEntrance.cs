using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionEntrance : MonoBehaviour
{
    /**
     * Lets the object know that the logic has been created to avoid repetitions
     */
    private bool hasCollided = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasCollided && other.CompareTag("Player"))
        {
            hasCollided = true;
            GenerateLevel.MakeMoreSectionsFrom(this.gameObject.transform.parent.transform.position);
        }
    }
}
