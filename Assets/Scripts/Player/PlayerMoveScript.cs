using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float moveSpeed = 130;
    public float rotationSpeed = 10;

    public float dashSpeed = 260;
    public float dashSecDuration = 0.3f;
    public float dashSecCoolDown = 1;


    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D rigidBody;
    private float timer = 0;
    private bool dashEnable = true;
    private bool isDashing = false;
    private float _realMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        SetActualSpeed();
    }

    public void Dash()
    {
        if (dashEnable is false) return;

        isDashing = true;
        dashEnable = false;
        timer = 0;
    }

    internal void MovePlayer(float horizontalInput, float verticalInput)
    {
        float horizontalMovement = horizontalInput * _realMoveSpeed;
        float verticalMovement = verticalInput * _realMoveSpeed;
        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, 0.05f);
        
        RotatePlayer(horizontalInput, verticalInput);
    }

    //_horizontalMovement should be equal to 1, -1 or 0 depend if the player moves right, left or none.
    private void RotatePlayer(float horizontalInput, float verticalInput)
    {
        Vector2 lookDir = new Vector2(-verticalInput, horizontalInput);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        if (lookDir.sqrMagnitude > 0.0f)
        {
            Quaternion target = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * rotationSpeed);
        }
    }

    private void SetActualSpeed()
    {
        timer += Time.deltaTime;

        if (isDashing)
        {
            isDashing = timer < dashSecDuration;
            _realMoveSpeed = dashSpeed;
            return;
        }

        if (!dashEnable)
        {
            dashEnable = timer >= dashSecCoolDown + dashSecDuration;
            _realMoveSpeed = moveSpeed;
            return;
        }

        _realMoveSpeed = moveSpeed;
    }
}