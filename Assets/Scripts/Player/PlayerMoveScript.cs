using System.Collections;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    // move
    public float moveSpeed = 130;
    public float rotationSpeed = 10;
    //dash
    public float dashSpeed = 260;
    public float dashSecDuration = 0.3f;
    public float dashSecCoolDown = 1;

    //optimisation
    private Rigidbody2D _rigidBody;
    private Transform _transform;
    private Animator _animator;
    
    private Vector3 _velocity = Vector3.zero;
    private bool _dashEnable = true;
    private float _realMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = transform;
        _animator = GetComponent<Animator>();
        _realMoveSpeed = moveSpeed;
    }

    public void Dash()
    {
        if (_dashEnable is false) return;

        StartCoroutine(DashSpeedAndCoolDownCoroutine());
    }

    internal void MovePlayer(float horizontalInput, float verticalInput)
    {
        float horizontalMovement = horizontalInput * _realMoveSpeed;
        float verticalMovement = verticalInput * _realMoveSpeed;
        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
        _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, targetVelocity, ref _velocity, 0.05f);
        
        _animator.SetBool("IsMoving", verticalMovement!=0 || horizontalMovement!=0 );
        
        RotatePlayer(horizontalInput, verticalInput);
    }

    private void RotatePlayer(float horizontalInput, float verticalInput)
    {
        Vector2 lookDir = new Vector2(-verticalInput, horizontalInput);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        if (lookDir.sqrMagnitude > 0.0f)
        {
            Quaternion target = Quaternion.Euler(0, 0, angle);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, target, Time.fixedDeltaTime * rotationSpeed);
        }
    }

    private IEnumerator DashSpeedAndCoolDownCoroutine()
    {
        _dashEnable = false;
        _realMoveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashSecDuration);

        _realMoveSpeed = moveSpeed;
        yield return new WaitForSeconds(dashSecCoolDown);

        _dashEnable = true;
    }
    
}