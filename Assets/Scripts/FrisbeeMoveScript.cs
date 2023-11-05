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
        ThrowFrisbee(velocity);
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPos != null) transform.position = _targetPos.position;
    }

    public void ThrowFrisbee(Vector2 velocity)
    {
        _rigidBody.freezeRotation = false;
        _rigidBody.totalTorque = torqueRotation;
        _targetPos = null;
        _rigidBody.velocity = velocity * speed;
    }

    public void CatchFrisbee(Transform targetPos)
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.freezeRotation = true;
        _targetPos = targetPos;
    }
    
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
