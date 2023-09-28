using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeMoveScript : MonoBehaviour
{
    public float baseSpeed = 100;

    public Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity * baseSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
