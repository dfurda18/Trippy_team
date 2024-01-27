using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UIElements;

public class Building : MonoBehaviour
{
    /**
     * The Building prefabs
     */
    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        (Instantiate(prefabs[UnityEngine.Random.Range(0,prefabs.Length)], this.gameObject.transform.position, Quaternion.Euler(0, (int)this.gameObject.GetComponentInParent<EnvironmentSection>().direction, 0)) as GameObject).transform.parent = this.gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
