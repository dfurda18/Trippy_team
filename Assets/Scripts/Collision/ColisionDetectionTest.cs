using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetectionTest : MonoBehaviour
{
    [SerializeField] private string colisionTag = "Player";
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("Colision!");
        }
    }
}
