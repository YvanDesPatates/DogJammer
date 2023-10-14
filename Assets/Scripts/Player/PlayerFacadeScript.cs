using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacadeScript : MonoBehaviour
{
    private PlayerMoveScript _playerMoveScript;
    private PlayerHeadScript _playerHeadScript;
    
    void Start()
    {
        _playerMoveScript = GetComponent<PlayerMoveScript>();
        _playerHeadScript = GetComponentInChildren<PlayerHeadScript>();
    }

    public void Move(float horizontalInput, float verticalInput)
    {
        _playerMoveScript.MovePlayer(horizontalInput, verticalInput);
    }
    
    public void Dash()
    {
        _playerMoveScript.Dash();
    }

    public void ThrowFrisbee()
    {
        _playerHeadScript.ThrowFrisbee();
    }
}
