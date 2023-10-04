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
    private CircleCollider2D _collider;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
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
        _collider.enabled = true;
        _rigidBody.velocity = velocity * speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void CatchFrisbee(Transform targetPos)
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.freezeRotation = true;
        _collider.enabled = false;
        _targetPos = targetPos;
    }
}
