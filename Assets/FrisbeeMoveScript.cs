using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeMoveScript : MonoBehaviour
{
    public float speed = 10;
    public float torqueRotation = 50;

    public Vector2 velocity;

    private Rigidbody2D _rigidBody;
    private Transform _targetPos;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        SetVelocity(velocity);
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPos != null) transform.position = _targetPos.position;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _targetPos = null;
        _rigidBody.totalTorque = torqueRotation  ;
        _rigidBody.velocity = velocity * speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetTargetPos(Transform targetPos)
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.totalTorque = 0  ;
        _targetPos = targetPos;
    }
}
