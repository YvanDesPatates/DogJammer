using System.Collections.Generic;
using DefaultNamespace;using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputManagerScript : MonoBehaviour, PlayerObserver
{
    public PlayerFacadeScript player1;
    public PlayerFacadeScript player2;

    public bool testMode1Player = false;

    private Dictionary<PlayerFacadeScript, Gamepad> mapPlayerAndPad;
    private bool _allGamepadWasAttributed = false;
    private ICommand _northButtonCommand;
    private ICommand _southButtonCommand;
    private ICommand _westButtonCommand;
    private ICommand _estButtonCommand;
    private ICommand _rightTriggerCommand;

    void Start()
    {
        mapPlayerAndPad = new Dictionary<PlayerFacadeScript, Gamepad>();
        mapPlayerAndPad.Add(player1, null);
        mapPlayerAndPad.Add(player2, null);
        SetButtonsCommandToVoid();
        _rightTriggerCommand = new DashCommand();
        
        player1.SubscribeAsObserver(this);
        player2.SubscribeAsObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_allGamepadWasAttributed)
        {
            SetUpGamePadMapping();
            return;
        }

        Move();
        
        
        if (mapPlayerAndPad[player1].buttonSouth.wasPressedThisFrame)
        {
            _southButtonCommand.Execute(player1);
        }

        if (mapPlayerAndPad[player1].buttonWest.wasPressedThisFrame)
        {
            _westButtonCommand.Execute(player1);
        }

        if (mapPlayerAndPad[player1].rightTrigger.wasPressedThisFrame)
        {
            _rightTriggerCommand.Execute(player1);
        }

        // only for testing purpose
        if (testMode1Player) return;

        if (mapPlayerAndPad[player2].buttonSouth.wasPressedThisFrame)
        {
            _southButtonCommand.Execute(player2);
        }

        if (mapPlayerAndPad[player2].buttonWest.wasPressedThisFrame)
        {
            _westButtonCommand.Execute(player2);
        }

        if (mapPlayerAndPad[player2].rightTrigger.wasPressedThisFrame)
        {
            _rightTriggerCommand.Execute(player2);
        }
    }

    private void Move()
    {
        player1.Move(mapPlayerAndPad[player1].leftStick.x.value, mapPlayerAndPad[player1].leftStick.y.value);
        if (testMode1Player) return;
        player2.Move(mapPlayerAndPad[player2].leftStick.x.value, mapPlayerAndPad[player2].leftStick.y.value);
    }

    private void SetUpGamePadMapping()
    {
        var gamepad = Gamepad.current;
        if (gamepad is null) return;

        if (mapPlayerAndPad[player1] is null)
        {
            mapPlayerAndPad[player1] = gamepad;
            if (testMode1Player) _allGamepadWasAttributed = true;
            return;
        }

        if (gamepad.Equals(mapPlayerAndPad[player1])) return;
        mapPlayerAndPad[player1] = gamepad;
        _allGamepadWasAttributed = true;
    }

    public void FrisbeeWasCatched(PlayerFacadeScript player)
    {
        SetButtonsCommandToVoid();
        var randomChoice = Random.Range(1, 4);
        switch (Random.Range(0, 4))
        {
            case <= 1:
                _northButtonCommand = new ThrowFrisbeeCommand();
                break;
            case <= 2:
                _southButtonCommand = new ThrowFrisbeeCommand();
                break;
            case <= 3:
                _westButtonCommand = new ThrowFrisbeeCommand();
                break;
            case <= 4:
                _estButtonCommand = new ThrowFrisbeeCommand();
                break;
        }
    }

    private void SetButtonsCommandToVoid()
    {
        _northButtonCommand = new VoidCommand();
        _southButtonCommand = new VoidCommand();
        _westButtonCommand = new VoidCommand();
        _estButtonCommand = new VoidCommand();
    }
}