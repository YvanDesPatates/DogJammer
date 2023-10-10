using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputManagerScript : MonoBehaviour
{
    public PlayerFacadeScript player1;
    public PlayerFacadeScript player2;

    public bool testMode1Player = false;

    private Gamepad _player1Gamepad;
    private Gamepad _player2Gamepad;
    private bool _allGamepadWasAttributed = false;
    private ICommand _southButtonCommand;
    private ICommand _westButtonCommand;

    void Start()
    {
        _southButtonCommand = new ThrowFrisbeeCommand();
        _westButtonCommand = new DashCommand();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_allGamepadWasAttributed)
        {
            SetUpGamePadMapping();
            return;
        }
        
        
        
        if (_player1Gamepad.buttonSouth.wasPressedThisFrame)
        {
            _southButtonCommand.Execute(player1);
        }

        if (_player1Gamepad.buttonWest.wasPressedThisFrame)
        {
            _westButtonCommand.Execute(player1);
        }

        if (testMode1Player) return;

        if (_player2Gamepad.buttonSouth.wasPressedThisFrame)
        {
            _southButtonCommand.Execute(player2);
        }

        if (_player2Gamepad.buttonWest.wasPressedThisFrame)
        {
            _westButtonCommand.Execute(player2);
        }
    }

    private void SetUpGamePadMapping()
    {
        var gamepad = Gamepad.current;
        if (gamepad is null) return;

        if (_player1Gamepad is null)
        {
            _player1Gamepad = gamepad;
            if (testMode1Player) _allGamepadWasAttributed = true;
            return;
        }

        if (gamepad.Equals(_player1Gamepad)) return;
        _player2Gamepad = gamepad;
        _allGamepadWasAttributed = true;
    }
}