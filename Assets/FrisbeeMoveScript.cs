using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeMoveScript : MonoBehaviour
{
    public float speed = 10;
    public float torqueRotation = 50;

    public Vector2 velocity;

    private Rigidbody2D rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SetVelocity(velocity);
        rigidBody.totalTorque = torqueRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void SetVelocity(Vector2 _velocity)
    {
        rigidBody.velocity = _velocity * speed;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }
}
