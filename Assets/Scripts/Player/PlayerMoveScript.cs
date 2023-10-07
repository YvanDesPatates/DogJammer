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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float realMoveSpeed = GetActualSpeed();

        float horizontalMovement = Input.GetAxis("Horizontal") * realMoveSpeed;
        float verticalMovement = Input.GetAxis("Vertical") * realMoveSpeed;
        MovePlayer(horizontalMovement, verticalMovement);

        int _horizontalDirection = Input.GetAxis("Horizontal") < 0 ? -1 : Input.GetAxis("Horizontal") > 0 ? 1 : 0;
        int _verticalDirection = Input.GetAxis("Vertical") < 0 ? -1 : Input.GetAxis("Vertical") > 0 ? 1 : 0;
        RotatePlayer(_horizontalDirection, _verticalDirection);

    }

    public void Dash()
    {
        if (dashEnable is false) return;
        
        isDashing = true;
        dashEnable = false;
        timer = 0;
    }

    private void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, 0.05f);
    }

    //_horizontalMovement should be equal to 1, -1 or 0 depend if the player moves right, left or none.
    private void RotatePlayer(int _horizontalDirection, int _verticalDirection)
    {
        if (_horizontalDirection != 0 || _verticalDirection != 0)
        {
            float zRotation = 0;
            if (_horizontalDirection != 0 && _verticalDirection != 0)
            {
                if (_horizontalDirection == -1 && _verticalDirection == -1)
                {
                    zRotation -= 135;
                }
                else
                {
                    float xRotation = _horizontalDirection < 0 ? 180 : 0;
                    float yRotation = 90 * _verticalDirection;
                    zRotation += (yRotation + xRotation) / 2;
                }

            }
            else
            {
                zRotation += _horizontalDirection < 0 ? 180 : 0;
                zRotation += 90 * _verticalDirection;
            }
            Quaternion target = Quaternion.Euler(0, 0, zRotation);

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
        }
    }

    private float GetActualSpeed()
    {
        timer += Time.deltaTime;

        if (isDashing)
        {
            isDashing = timer < dashSecDuration;
            return dashSpeed;
        }

        if (!dashEnable)
        {
            dashEnable = timer >= dashSecCoolDown + dashSecDuration;
            return moveSpeed;
        }

        return moveSpeed;
    }

}
